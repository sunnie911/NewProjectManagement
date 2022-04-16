using DanaZhangCms.Core.DbContextCore;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.IRepositories;
using DanaZhangCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanaZhangCms.Repositories
{
    public class SysUserRepository : BaseRepository<SysUser, int>, ISysUserRepository
    {
        public SysUserRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

        public (bool, SysUser) Login(string account, string password, string ip)
        {
            var result = false;
            var model = GetSingleOrDefault(m =>
                (m.SysUserName.Equals(account)
                 || m.Telephone.Equals(account)
                 || m.EMail.Equals(account, StringComparison.OrdinalIgnoreCase))
                && password.Equals(m.Password));
            if (model != null && model.Activable)
            {
                model.LatestLoginDateTime = DateTime.Now;
                model.LatestLoginIP = ip;

                Update(model, false, "LatestLoginDateTime", "LatestLoginIP");
                result = true;
            }

            return (result, model);
        }

        public bool SignUp(string telephone, string userName, string password, string email)
        {
            var model = new SysUser()
            {
                Telephone = telephone,
                SysUserName = userName,
                Password = password,

                EMail = email,
                Activable = true,
                CreatedDate = System.DateTime.Now
            };
            return Add(model) > 0;
        }

        public (bool, string) EditProfile(int userId, string telephone, string userName, string email)
        {
            var entity = GetSingle(userId);
            if (entity == null)
                return (false, "不存在的账户");
            if (!entity.Activable)
                return (false, "该账户已被停用");
            var updateColumns = new List<string>();
            if (!string.IsNullOrEmpty(telephone))
            {
                entity.Telephone = telephone;
                updateColumns.Add("Telephone");
            }

            if (!string.IsNullOrEmpty(userName))
            {
                entity.SysUserName = userName;
                updateColumns.Add("SysUserName");
            }
            if (!string.IsNullOrEmpty(email))
            {
                entity.EMail = email;
                updateColumns.Add("EMail");
            }

            if (updateColumns.Any())
            {
                return Update(entity, false, updateColumns.ToArray()) > 0 ? (true, "操作成功") : (false, "操作失败");
            }

            return (false, "未做任何更改");
        }

        public (bool, string) ChangePassword(int userId, string oldPwd, string newPwd)
        {
            var entity = GetSingle(userId);
            if (entity == null)
                return (false, "不存在的账户");
            if (!entity.Activable)
                return (false, "该账户已被停用");
            if (!entity.Password.Equals(oldPwd))
                return (false, "密码错误");
            entity.Password = newPwd;
            return Update(entity, false, "Password") > 0 ? (true, "操作成功") : (false, "操作失败");
        }

        public (bool, string) ChangePassword(int userId,string newPwd)
        {
            var entity = GetSingle(userId);
            if (entity == null)
                return (false, "不存在的账户");
            if (!entity.Activable)
                return (false, "该账户已被停用");
            entity.Password = newPwd;
            return Update(entity, false, "Password") > 0 ? (true, "操作成功") : (false, "操作失败");
        }


        public (bool, string) Active(int userId, bool activable)
        {
            var entity = GetSingle(userId);
            if (entity == null)
                return (false, "不存在的账户");
            entity.Activable = activable;
            return Update(entity, false, "Activable") > 0 ? (true, "操作成功") : (false, "操作失败");
        }
    }
}