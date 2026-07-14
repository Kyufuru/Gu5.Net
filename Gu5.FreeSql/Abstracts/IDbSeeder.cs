using System.Threading.Tasks;

using Gu5.AspNet.Abstracts;

namespace Gu5.FreeSql.Abstracts
{
    /// <summary>
    /// 需要初始化数据库表时, 实现该接口
    /// </summary>
    public interface IDbSeeder : IInject 
    {
        /// <summary>
        /// 数据初始化事件
        /// </summary>
        /// <returns></returns>
        Task OnInitAsync(IFreeSql dbo);
    }

    /// <inheritdoc/>
    /// <typeparam name="TD">数据库</typeparam>
    /// <typeparam name="TE">表</typeparam>
    public interface IDbSeeder<TD, TE> : IDbSeeder 
        where TD : IDatabase
        where TE : class, new()
    { 
    }
}
