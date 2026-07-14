using System;

using FreeSql.DataAnnotations;

namespace Gu5.FreeSql
{

    /// <summary>
    /// 标识
    /// </summary>
    /// <typeparam name="T">主键类型</typeparam>
    public abstract class Entity<T>
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Column(IsPrimary = true)]
        public T Id { get; set; }
    }

    /// <summary>
    /// 标识
    /// </summary>
    public abstract class Entity : Entity<int>
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Column(IsPrimary = true, IsIdentity = true)]
        public new int Id { get; set; }
    }

    /// <summary>
    /// 时间
    /// </summary>
    public abstract class DateEntity<T> : Entity<T>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(ServerTime = DateTimeKind.Local, CanUpdate = false)]
        public DateTime CreateTime { get; set; }
    }

    /// <summary>
    /// 时间
    /// </summary>
    public abstract class DateEntity : DateEntity<int>
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Column(IsPrimary = true, IsIdentity = true)]
        public new int Id { get; set; }
    }

    /// <summary>
    /// 软删除
    /// </summary>
    public abstract class DelEntity<T> : DateEntity<T>
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }
    }

    /// <summary>
    /// 软删除
    /// </summary>
    public abstract class DelEntity : DelEntity<int>
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Column(IsPrimary = true, IsIdentity = true)]
        public new int Id { get; set; }
    }
}
