﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT
{
    /// <summary>
    /// Статусы ответа
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// Операция была успешно выполнена
        /// </summary>
        Success = 0,

        /// <summary>
        /// Операция была выполнена с ошибкой
        /// </summary>
        Error = 1,

        /// <summary>
        /// Операция была выполнена с ошибкой по причине некорректных входных данных (ошибки валидации прилагаются)
        /// </summary>
        ValidationError = 2,

    }
}