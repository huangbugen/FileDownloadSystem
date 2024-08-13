using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileDownLoadSystem.Core.Enums;

namespace FileDownLoadSystem.Core.Extensions
{
    public static class LambdaExtensions
    {
        /// <summary>
        /// 设计排序的表达式字典
        /// </summary>
        /// <param name="expression"></param>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, QueryOrderBy> GetExpressionToDic<TModel>(
            this Expression<Func<TModel, Dictionary<object, QueryOrderBy>>> expression
        )
        {
            if (expression == null)
            {
                return new Dictionary<string, QueryOrderBy>();
            }
            var res = expression.GetExpressionToPair().Reverse().ToList().ToDictionary(x => x.Key, x => x.Value);
            return res;
        }


        /// <summary>
        /// 将表达式中的排序字典拼接成表达式
        /// </summary>
        /// <param name="expression"></param>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<string, QueryOrderBy>> GetExpressionToPair<TModel>(
            this Expression<Func<TModel, Dictionary<object, QueryOrderBy>>> expression
        )
        {
            foreach (var exp in ((ListInitExpression)expression.Body).Initializers)
            {
                string key = exp.Arguments[0] is MemberExpression
                    ? (exp.Arguments[0] as MemberExpression)!.Member.Name
                    : ((exp.Arguments[0] as UnaryExpression)!.Operand as MemberExpression)!.Member.Name;

                QueryOrderBy value = (QueryOrderBy)(exp.Arguments[1] as ConstantExpression != null
                        ? (exp.Arguments[1] as ConstantExpression)!.Value
                        : Expression.Lambda<Func<QueryOrderBy>>(exp.Arguments[1] as Expression).Compile()())!;

                yield return new KeyValuePair<string, QueryOrderBy>(key, value);

                // yield return new KeyValuePair<string, QueryOrderBy>(
                //     exp.Arguments[0] is MemberExpression ?
                //         (exp.Arguments[0] as MemberExpression).Member.Name
                //         : ((exp.Arguments[0] as UnaryExpression).Operand as MemberExpression).Member.Name
                //     ,
                //     (QueryOrderBy)(
                //         exp.Arguments[1] as ConstantExpression != null
                //         ? (exp.Arguments[1] as ConstantExpression).Value
                //         : Expression.Lambda<Func<QueryOrderBy>>(exp.Arguments[1] as Expression).Compile()()
                //     )
                // );
            }
        }

        /// <summary>
        /// 拼接表达式
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="orderBySelector"></param>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public static IQueryable<TModel> GetIQueryOrderBy<TModel>(
            this IQueryable<TModel> queryable,
            Dictionary<string, QueryOrderBy> orderBySelector)
        {
            string[] orderByKeys = orderBySelector.Select(x => x.Key).ToArray();
            if (orderByKeys == null || orderByKeys.Length == 0)
            {
                return queryable;
            }
            // 如果存在则重组Queryable
            IOrderedQueryable<TModel> queryableOrderBy = null;
            string orderByKey = orderByKeys[orderByKeys.Length - 1];
            queryableOrderBy = orderBySelector[orderByKey] == QueryOrderBy.Desc
                ? queryableOrderBy = queryable.OrderByDescending(orderByKey.GetExpression<TModel>())
                : queryableOrderBy = queryable.OrderBy(orderByKey.GetExpression<TModel>());
        }

        public static Expression<Func<TModel, object>> GetExpression<TModel>(this string propertyName)
        {
            return propertyName.GetExpression<TModel, object>(typeof(TModel).GetExpressionParameter());
        }

        public static Expression<Func<TModel, TKey>> GetExpression<TModel, TKey>(this string propertyName, ParameterExpression parameterExpression)
        {
            if (typeof(TKey).Name == "Object")
            {

                var res = Expression.Lambda<Func<TModel, TKey>>(Expression.Convert(Expression.Property(parameterExpression, propertyName), typeof(object)), parameterExpression);

                return res;
            }
            return Expression.Lambda<Func<TModel, TKey>>(Expression.Property(parameterExpression, propertyName), parameterExpression);
        }

        public static ParameterExpression GetExpressionParameter(this Type type)
        {
            return Expression.Parameter(type, "p");
        }
    }
}