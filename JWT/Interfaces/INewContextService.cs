using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface INewContextService
    {
		#region Subject
		/// <summary>
		/// Добавить новый предмет
		/// </summary>
		/// <param name="subjects"></param>
		Task<aSubjects> AddSubject(aSubjects subjects);

        /// <summary>
        /// Редактировать предмет
        /// </summary>
        /// <param name="subjects"></param>
        Task<aSubjects> EditSubject(aSubjects subjects);

        /// <summary>
        /// Удалить предмет
        /// </summary>
        /// <param name="idsubjects"> Ид предмета</param>
        Task<aSubjects> DeleteSubject(int idsubjects);

        /// <summary>
        /// Получить все предмет
        /// </summary>
        Task<aSubjects[]> GetSubjects();

        /// <summary>
        /// Получить предмет
        /// </summary>
        /// <param name="idsubjects"> Ид предмета</param>
        Task<aSubjects> GetSubject(int idsubjects);
		#endregion
		#region Test
		/// <summary>
		/// Добавить новый тест
		/// </summary>
		/// <param name="test"></param>
		/// <param name="numberNode"></param>
		Task<aTests> AddTest(aTests test, int numberNode);

        /// <summary>
        /// Редактировать предмет
        /// </summary>
        /// <param name="tests"></param>
        Task<aTests> EditTest(aTests tests);

        /// <summary>
        /// Удалить предмет
        /// </summary>
        /// <param name="idTest"> Ид теста</param>
        Task<aTests> DeleteTest(int idTest);

        /// <summary>
        /// Получить все предмет
        /// </summary>
        Task<aTests[]> GetTests();

        /// <summary>
        /// Получить предмет
        /// </summary>
        /// <param name="idTest"> Ид теста</param>
        Task<aTests> GetTest(int idTest);
		#endregion
		#region Task
		/// <summary>
		/// Добавить новую задачу
		/// </summary>
		/// <param name="exercises"></param>
		Task<aExercises> AddExercises(aExercises exercises);

        /// <summary>
        /// Редактировать задачу
        /// </summary>
        /// <param name="exercises"></param>
        Task<aExercises> EditExercises(aExercises exercises);

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="idExercises"></param>
        Task<aExercises> DeleteExercises(int idExercises);

        /// <summary>
        /// Получить все задачи
        /// </summary>
        Task<aExercises[]> GetExercisess();

        /// <summary>
        /// Получить задачу
        /// </summary>
        /// <param name="idExercises"></param>
        Task<aExercises> GetExercises(int idExercises);

        /// <summary>
        /// Получить следующую задачу
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="test"></param>
        Task<aExercises> GetExercises(int IdUser,int test);

        /// <summary>
        /// Проверить решение задачи
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idTask"></param>
        /// <param name="answer"></param>
        /// <param name="parent"></param>
        Task<bool> AnswerTask(int idUser, int idTask, string answer, int parent);

		#endregion
		/// <summary>
		/// Начать изучать предмет
		/// </summary>
		/// <param name="aHierarchySubjectsUsers"> Иерархия </param>
		/// <returns></returns>
		Task<aHierarchySubjectsUsers> StartListen(aHierarchySubjectsUsers aHierarchySubjectsUsers);

        /// <summary>
        /// Получить всю иерархию
        /// </summary>
        Task<aHierarchySubjectsUsers[]> GetHierarchySubjectsUsers();

        /// <summary>
        /// Получить всю иерархию пользователя
        /// </summary>
        Task<aHierarchySubjectsUsers[]> GetHierarchySubjectsUsers(int idUser);
    }
}
