namespace JWT.Core
{
    /// <summary>
    /// Ответ от компиляторов онлайн
    /// </summary>
    class ResponceCompile
    {
        /// <summary>
        ///  Результат работы скрипта
        /// </summary>
        public string output { get; set; }

        /// <summary>
        /// Статус код
        /// </summary>
        public int statusCode { get; set; }

        /// <summary>
        /// Выделенная память
        /// </summary>
        public string memory { get; set; }

        /// <summary>
        /// Процессорное время
        /// </summary>
        public string cpuTime { get; set; }
    }
}
