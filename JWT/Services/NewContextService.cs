using JWT.Interfaces;
using JWT.Models;
using JWT.NewApplogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

namespace JWT.Services
{
    /// <inheritdoc/>
    public class NewContextService : INewContextService
    {
        private readonly ApplicationContext _context;

        public NewContextService(ApplicationContext _applicationContext) =>
           _context = _applicationContext;

        /// <inheritdoc/>
        public async Task<aSubjects> AddSubject(aSubjects subjects)
        {
            _context.aSubjects.Add(subjects);
            await _context.SaveChangesAsync();

            return subjects;
        }


        /// <inheritdoc/>
        public async Task<aSubjects> UpdateSubject(aSubjects subjects)
        {
            _context.aSubjects.Update(subjects);
            await _context.SaveChangesAsync();

            return subjects;
        }


        /// <inheritdoc/>
        public async Task<aSubjects> DeleteSubject(int idSubject)
        {
            var subjects = _context.aSubjects.FirstOrDefault(x => x.IdSubject == idSubject);
            _context.aSubjects.Remove(subjects);
            await _context.SaveChangesAsync();

            return subjects;
        }

        /// <inheritdoc/>
        public async Task<aHierarchySubjectsUsers> StartListen(aHierarchySubjectsUsers aHierarchySubjectsUsers)
        {
            var allTest = _context.aTests.Where(x => x.IdSubject == aHierarchySubjectsUsers.IdSubject).ToList();
            var minRating = _context.aExercises
                .Where(x => x.IdTest == allTest[0].IdTest)
                .Min(x => x.LevelExercises);
            aHierarchySubjectsUsers.IdTest =  _context.aExercises
                .FirstOrDefaultAsync(x=>x.IdTest == allTest[0].IdTest && x.LevelExercises == minRating).Result.IdTest;
            _context.aHierarchySubjectsUsers.Add(aHierarchySubjectsUsers);
            
            await _context.SaveChangesAsync();

            return aHierarchySubjectsUsers;
        }

        private aHierarchySubjectsUsers MapTest(aTests tests, int depth)
        {
            return new aHierarchySubjectsUsers
            {
                Key = 0,
                IdUser = null,
                IdTest = tests.IdTest,
                IdSubject = tests.IdSubject,
                Rating = 0,
                Depth = depth
            };
        }

        /// <inheritdoc/>
        public async Task<aTests> AddTest(aTests test, int depth)
        {
            _context.aTests.Add(test);

            _context.aHierarchySubjectsUsers.Add((MapTest(test, depth)));

            await _context.SaveChangesAsync();

            return test;
        }

        /// <inheritdoc/>
        public async Task<bool> AnswerTask(int idUser, int idTask, string answer, int parent)
        {
            var task = _context.aExercises.FirstOrDefault(x => x.IdExercises == idTask);
            var test = _context.aTests.FirstOrDefault(x=> x.IdTest == task.IdTest);

            if (task != null)
            {
                _context.aCompleateExercises.Add(new aCompleateExercises { IdExercises = idTask, IdUser = idUser });
                var hierarchySubjects = _context.aHierarchySubjectsUsers.Where(x => x.IdSubject == test.IdSubject && x.IdUser == null && test.IdTest == x.IdTest)
                    .ToList();
                var cheackHiararchy = _context.aHierarchySubjectsUsers.Where(x => x.IdUser == idUser && x.IdSubject == test.IdSubject)
                    .Count() > 0;

                if (cheackHiararchy)
                {
                    aHierarchySubjectsUsers AddaHierarchySubjectsUsers = new aHierarchySubjectsUsers();
                    AddaHierarchySubjectsUsers.IdSubject = test.IdSubject;
                    AddaHierarchySubjectsUsers.IdTest = test.IdTest;
                    AddaHierarchySubjectsUsers.IdUser = idUser;
                    AddaHierarchySubjectsUsers.Rating = task.LevelExercises;
                    AddaHierarchySubjectsUsers.IdParent = parent;
                    _context.aHierarchySubjectsUsers.Add(AddaHierarchySubjectsUsers);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var updatehir = _context.aHierarchySubjectsUsers.FirstOrDefault(x => x.IdUser == idUser && x.IdTest == test.IdTest);
                    updatehir.Rating += task.LevelExercises;
                    _context.aHierarchySubjectsUsers.Update(updatehir);
                    await _context.SaveChangesAsync();
                }

                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public async Task<aExercises> AddExercises(aExercises exercises)
        {
            _context.aExercises.Add(exercises);
            await _context.SaveChangesAsync();

            return exercises;
        }

        /// <inheritdoc/>
        public async Task<aExercises> GetExercises(int idUser, int test)
        {
            var tasks = await _context.aExercises.ToListAsync();
            var ratingUserFromTest = await _context.aHierarchySubjectsUsers.FirstOrDefaultAsync(x => x.IdTest == test && x.IdUser == idUser);
            foreach (var item in tasks)
            {
                if (formularRating(ratingUserFromTest.Rating , item.LevelExercises) < 0.8)
                {
                    return item;
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public async Task<aExercises> Skip(int idUser, int test, int idTask)
        {
            var tasks = _context.aExercises.Where(x => x.IdTest == test).ToArray();
            var ratingUserFromTest = await _context.aHierarchySubjectsUsers.FirstOrDefaultAsync(x => x.IdTest == test && x.IdUser == idUser);
            foreach (var item in tasks)
            {
                if (formularRating(ratingUserFromTest.Rating, item.LevelExercises) < 0.80 && item.IdExercises != idTask)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Формула расчета TODO вынести в отедльный класс
        /// </summary>
        /// <param name="RatingTest"></param>
        /// <param name="LevelExercise"></param>
        /// <returns></returns>
        public  double formularRating(double RatingTest, double LevelExercise)
        {
            return (1 - 0.05) / (1 + Math.Pow(2.7, -1 * (RatingTest - LevelExercise)));
        }

        /// <inheritdoc/>
        public async Task<aSubjects> EditSubject(aSubjects subjects)
        {
            _context.aSubjects.Update(subjects);
            await _context.SaveChangesAsync();
            
            return subjects;
        }

        /// <inheritdoc/>
        public async Task<aSubjects[]> GetSubjects()
        {
            return await _context.aSubjects.ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<aSubjects> GetSubject(int idsubjects)
        {
            return await _context.aSubjects.FirstOrDefaultAsync(x => x.IdSubject == idsubjects);
        }

        /// <inheritdoc/>
        public async Task<aTests> EditTest(aTests tests)
        {
            _context.aTests.Update(tests);
            await _context.SaveChangesAsync();

            return tests;
        }

        /// <inheritdoc/>
        public async Task<aTests> DeleteTest(int idTest)
        {
            var test = await _context.aTests.FirstOrDefaultAsync(x => x.IdTest == idTest);
            _context.aTests.Remove(test);
            await _context.SaveChangesAsync();

            return test;
        }

        /// <inheritdoc/>
        public async Task<aTests[]> GetTests()
        {
            return await _context.aTests.ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<aTests> GetTest(int idTest)
        {
            return await _context.aTests.FirstOrDefaultAsync(x => x.IdTest == idTest);
        }

        /// <inheritdoc/>
        public async Task<aExercises> EditExercises(aExercises exercises)
        {
            _context.aExercises.Update(exercises);
            await _context.SaveChangesAsync();

            return exercises;
        }

        /// <inheritdoc/>
        public async Task<aExercises> DeleteExercises(int idExercises)
        {
            var task = await _context.aExercises.FirstOrDefaultAsync(x => x.IdExercises == idExercises);
            _context.aExercises.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        /// <inheritdoc/>
        public async Task<aExercises[]> GetExercisess()
        {
            return await _context.aExercises.ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<aExercises> GetExercises(int idExercises)
        {
            return await _context.aExercises.FirstOrDefaultAsync(x => x.IdExercises == idExercises);
        }

        /// <inheritdoc/>
        public async Task<aHierarchySubjectsUsers[]> GetHierarchySubjectsUsers()
        {
            return await _context.aHierarchySubjectsUsers.ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<aHierarchySubjectsUsers[]> GetHierarchySubjectsUsers(int idUser)
        {
            return await _context.aHierarchySubjectsUsers.Where(x => x.IdUser == idUser).ToArrayAsync();
        }
    }
}
