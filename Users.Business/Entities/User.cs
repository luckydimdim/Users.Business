﻿using System;
using System.Collections.Generic;

namespace Cmas.BusinessLayers.Users.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный внутренний идентификатор
        /// </summary>
        public string Id;

        /// <summary>
        ///
        /// </summary>
        public string Rev;

        /// <summary>
        /// Дата и время создания
        /// </summary>
        public DateTime CreatedAt;

        /// <summary>
        /// Дата и время обновления
        /// </summary>
        public DateTime UpdatedAt;

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name;

        /// <summary>
        /// Хэш пароля
        /// </summary>
        public string PasswordHash;

        /// <summary>
        /// Хэш активации
        /// </summary>
        public string actHash;

        /// <summary>
        /// Роли
        /// </summary>
        public IEnumerable<string> Roles;

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> Groups;
    }
}
