﻿using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Implementations;
using HelloFriendsAPI.ViewModels;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public class RespostasVFBusinessImplementation : IRespostasVFBusiness
    {
        private readonly IRespostasVFRepository _repository;
        private readonly IMapper _mapper;

        public RespostasVFBusinessImplementation(IRespostasVFRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public RespostasVF Create(RespostasVFViewModel respostasViewModel)
        {

            var consulta = _repository.FindByAlunoAtividade(respostasViewModel.AlunoId, respostasViewModel.VerdadeiroFalsoID);
            if (consulta == null)
            {
                return _repository.Create(_mapper.Map<RespostasVF>(respostasViewModel));
            }
            else
            {
                respostasViewModel.Id = consulta.Id;
                return _repository.Update(_mapper.Map<RespostasVF>(respostasViewModel));
            }
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<RespostasVF> FindAll()
        {

            return _repository.FindAll();
        }

        public RespostasVF FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public List<RespostasVF> FindByModuloAluno(long idModulo, long idAluno)
        {
            return _repository.FindByModuloAluno(idModulo, idAluno);
        }

        public RespostasVF Update(RespostasVFViewModel respostasVFViewModel)
        {

            return _repository.Update(_mapper.Map<RespostasVF>(respostasVFViewModel));
        }
    }
}
