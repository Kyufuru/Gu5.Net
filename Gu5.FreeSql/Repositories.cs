using System;
using System.Collections.Generic;

using FreeSql;

using Gu5.Core;
using Gu5.Core.Http;
using Gu5.FreeSql.Abstracts;

using Mapster;

namespace Gu5.FreeSql
{
    /// <summary>
    /// 基础仓储
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class BaseRepo<T, TKey> : IRepository<T, TKey> 
        where T : Entity<TKey>, new()
    {
        /// <inheritdoc/>
        public virtual IFreeSql Dbo { get; set; }
        public BaseRepo(IFreeSql dbo) => Dbo = dbo;

        /// <inheritdoc/>
        public virtual void Add(IEnumerable<T> l) => Dbo.Cascade<T>().Insert(l);

        /// <inheritdoc/>
        public virtual T AddOne(T d) => Dbo.Cascade<T>().Insert(d);

        /// <inheritdoc/>
        public virtual void Del(IEnumerable<T> l) => Dbo.Cascade<T>().Delete(l);

        /// <inheritdoc/>
        public virtual void DelOne(TKey id) => Dbo.Cascade<T>().Delete(new T { Id = id });

        /// <inheritdoc/>
        public virtual void SetAll(IEnumerable<T> l) => Dbo.Cascade<T>().Update(l);

        /// <inheritdoc/>
        public virtual void SetOne(T d) => Dbo.Cascade<T>().Update(d);

        /// <inheritdoc/>
        public virtual List<T> GetAll() => Dbo.Select<T>().ToList();

        /// <inheritdoc/>
        public List<TR> GetAll<TR>() => GetAll().Adapt<List<TR>>();

        /// <inheritdoc/>
        public virtual T GetOne(TKey id) => Dbo.Select<T>().Where(x => x.Id.Equals(id)).ToOne();

        /// <inheritdoc/>
        public TR GetOne<TR>(TKey id) => GetOne(id).Adapt<TR>();
    }

    /// <inheritdoc/>
    public class BaseRepo<T> : BaseRepo<T, int>
        where T : Entity, new() 
    {
        public BaseRepo(IFreeSql dbo) : base(dbo) { }
    }

    /// <summary>
    /// 带过滤条件的仓储
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    /// <typeparam name="TFlt">筛选条件</typeparam>
    public class FltRepo<T, TKey, TFlt> : BaseRepo<T, TKey>
        where T : Entity<TKey>, new()
        where TFlt: BaseFlt
    {
        public FltRepo(IFreeSql dbo) : base(dbo) { }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="d">筛选条件</param>
        /// <returns>分页响应体</returns>
        public virtual PageRsp<T> Flt(TFlt d, Func<ISelect<T>, ISelect<T>> f)
        {
            var rs = f(Dbo.Select<T>())
                .Page(d.Page, out var tot)
                .ToList();

            return new PageRsp<T>(rs, tot);
        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="d">筛选条件</param>
        /// <returns>分页响应体</returns>
        public virtual PageRsp<TR> Flt<TR>(TFlt d, Func<ISelect<T>, ISelect<T>> f) 
        {
            var rs = Flt(d, f);
            var l = rs.Data.Adapt<List<TR>>();
            var tot = rs.Total;

            return new PageRsp<TR>(l, tot);
        }
    }

    /// <inheritdoc/>
    public class FltRepo<T, TFlt> : FltRepo<T, int, TFlt>
        where T : Entity, new()
        where TFlt : BaseFlt
    {
        public FltRepo(IFreeSql dbo) : base(dbo) { }
    }

    /// <summary>
    /// 逻辑删除仓储
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    public class DelRepo<T, TKey> : BaseRepo<T, TKey>
        where T : DelEntity<TKey>, new()
    {
        public DelRepo(IFreeSql dbo) : base(dbo) { }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="l">列表</param>
        public override void Del(IEnumerable<T> l) =>
            base.SetAll(l.ForEach(x => x.IsDeleted = true));

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id">标识</param>
        public override void DelOne(TKey id)
        {
            var d = base.GetOne(id);
            base.SetOne(d.Also(x => x.IsDeleted = true));
        }
    }

    /// <summary>
    /// 逻辑删除仓储
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class DelRepo<T> : DelRepo<T, int>
        where T : DelEntity, new()
    {
        public DelRepo(IFreeSql dbo) : base(dbo) { }
    }

    /// <summary>
    /// 过滤+逻辑删除仓储
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    /// <typeparam name="TFlt">筛选条件</typeparam>
    public class DelFltRepo<T, TKey, TFlt> : DelRepo<T, TKey>
        where T : DelEntity<TKey>, new()
        where TFlt : BaseFlt
    {
        public DelFltRepo(IFreeSql dbo) : base(dbo) { }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="d">筛选条件</param>
        /// <returns>分页响应体</returns>
        public virtual PageRsp<T> Flt(TFlt d, Func<ISelect<T>, ISelect<T>> f)
        {
            var rs = f(Dbo.Select<T>())
                .Where(x => !x.IsDeleted)
                .Page(d.Page, out var tot)
                .ToList();

            return new PageRsp<T>(rs, tot);
        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="d">筛选条件</param>
        /// <returns>分页响应体</returns>
        public virtual PageRsp<TR> Flt<TR>(TFlt d, Func<ISelect<T>, ISelect<T>> f)
        {
            var rs = Flt(d, f);
            var l = rs.Data.Adapt<List<TR>>();
            var tot = rs.Total;

            return new PageRsp<TR>(l, tot);
        }
    }

    /// <summary>
    /// 过滤+逻辑删除仓储
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TFlt">筛选条件</typeparam>
    public class DelFltRepo<T, TFlt> : DelFltRepo<T, int, TFlt>
        where T : DelEntity<int>, new()
        where TFlt : BaseFlt
    {
        public DelFltRepo(IFreeSql dbo) : base(dbo) { }
    }
}