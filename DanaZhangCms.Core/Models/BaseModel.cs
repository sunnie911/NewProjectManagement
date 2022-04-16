using System;
using System.ComponentModel.DataAnnotations;

namespace DanaZhangCms.Core.Models
{
    public interface IAggregateRoot
    {

    }
    /// <summary>
    /// 所有数据表实体类都必须实现此接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [Serializable]
    public abstract class BaseModel<TKey> : IAggregateRoot
    {
        protected BaseModel()
        {
            IsDeleted = false;
            UpdateDate = DateTime.Now;
            CreatedDate = DateTime.Now;
            // UniqueId = Helpers.CommonHelper.NewMongodbId().ToString();
        }

        [Key]
        public TKey Id { get; set; }

        // public  string UniqueId { get; set; }

        ///// <summary>
        /////  删除，逻辑上的删除，非物理删除
        ///// </summary>
        public bool IsDeleted { get; set; }


        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
