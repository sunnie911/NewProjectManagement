using System;
using DanaZhangCms.Core.Attributes;
using DanaZhangCms.Core.Repositories;
using DanaZhangCms.Models;

namespace DanaZhangCms.IRepositories
{
    public interface ISysUserRepository:IRepository<SysUser, int>
    {
        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        (bool, SysUser) Login(string account, string password, string ip);
        /// <summary>
        /// ע��
        /// </summary>
        /// <param name="telephone"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        bool SignUp(string telephone, string userName, string password, string email);
        /// <summary>
        /// ????????
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="telephone"></param>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        (bool, string) EditProfile(int userId, string telephone, string userName, string email);
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        (bool, string) ChangePassword(int userId, string oldPwd, string newPwd);

        /// <summary>
        /// ��̨�޸�����
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        (bool, string) ChangePassword(int userId, string newPwd);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="activable"></param>
        /// <returns></returns>
        (bool, string) Active(int userId, bool activable);
    }
}