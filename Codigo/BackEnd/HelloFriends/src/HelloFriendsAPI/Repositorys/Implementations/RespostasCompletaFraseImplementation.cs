﻿using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public class RespostasCompletaFraseImplementation : IRespostasCompletaFraseRepository
    {
        private HelloFriendsContext _context;

        public RespostasCompletaFraseImplementation(HelloFriendsContext context)
        {
            _context = context;
        }

        public RespostasCompleFrase Create(RespostasCompleFrase respostasCompleFrase)
        {
            try
            {
                _context.Add(respostasCompleFrase);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return respostasCompleFrase;
        }

        public void Delete(long id)
        {
            var result = _context.RespostasCompleFrase.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.RespostasCompleFrase.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        
        public bool Exists(long id)
        {
            return _context.RespostasCompleFrase.Any(p => p.Id.Equals(id));
        }

        public List<RespostasCompleFrase> FindAll()
        {
            var result = _context.RespostasCompleFrase.Include(p => p.Aluno).Include(p => p.CompletaFrase).ToList();

            return result;
        }

        public RespostasCompleFrase FindByID(long id)
        {
            return _context.RespostasCompleFrase.SingleOrDefault(p => p.Id.Equals(id));
        }

        public RespostasCompleFrase FindByAlunoAtividade(long idAluno, Guid idAtividade)
        {
            return _context.RespostasCompleFrase.SingleOrDefault(p => p.AlunoId.Equals(idAluno) && p.CompletaFraseID.Equals(idAtividade));
        }

        public List<RespostasCompleFrase> FindByModuloAluno(long idModulo, long idAluno)
        {
            return _context.RespostasCompleFrase.Where(p => p.MId.Equals(idModulo) && p.AlunoId.Equals(idAluno)).ToList();
        }

        public RespostasCompleFrase Update(RespostasCompleFrase respostasCompleFrase)
        {
            if (!Exists(respostasCompleFrase.Id)) return null;

            var result = _context.RespostasCompleFrase.SingleOrDefault(p => p.Id.Equals(respostasCompleFrase.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(respostasCompleFrase);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return respostasCompleFrase;
        }

        
    }
}
