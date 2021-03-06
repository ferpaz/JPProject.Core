using AutoMapper;
using IdentityServer4.Models;
using JPProject.Admin.Application.AutoMapper;
using JPProject.Admin.Application.Interfaces;
using JPProject.Admin.Application.ViewModels.ClientsViewModels;
using JPProject.Admin.Domain.Commands.Clients;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.Interfaces;
using JPProject.Domain.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPProject.Admin.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private IMapper _mapper;
        private IEventStoreRepository _eventStoreRepository;
        private readonly IClientRepository _clientRepository;
        public IMediatorHandler Bus { get; set; }

        public ClientAppService(
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository,
            IClientRepository clientRepository)
        {
            _mapper = AdminClientMapper.Mapper;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientListViewModel>> GetClients()
        {
            var clients = await _clientRepository.All();
            var resultado = _mapper.Map<IEnumerable<ClientListViewModel>>(clients);
            return resultado;
        }

        public async Task<Client> GetClientDetails(string clientId)
        {
            var resultado = await _clientRepository.GetClient(clientId);
            return _mapper.Map<Client>(resultado);
        }

        public Task<bool> Update(string id, Client client)
        {
            var updateClientCommand = new UpdateClientCommand(client, id);
            return Bus.SendCommand(updateClientCommand);
        }

        public Task<IEnumerable<Secret>> GetSecrets(string clientId)
        {
            return _clientRepository.GetSecrets(clientId);
        }

        public Task<bool> RemoveSecret(RemoveClientSecretViewModel model)
        {
            var registerCommand = _mapper.Map<RemoveClientSecretCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public Task<bool> SaveSecret(SaveClientSecretViewModel model)
        {
            var registerCommand = _mapper.Map<SaveClientSecretCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public async Task<IEnumerable<ClientPropertyViewModel>> GetProperties(string clientId)
        {
            return _mapper.Map<IEnumerable<ClientPropertyViewModel>>(await _clientRepository.GetProperties(clientId));
        }

        public Task<bool> RemoveProperty(RemovePropertyViewModel model)
        {
            var registerCommand = _mapper.Map<RemovePropertyCommand>(model);
            return Bus.SendCommand(registerCommand);
        }
        public Task<bool> SaveProperty(SaveClientPropertyViewModel model)
        {
            var registerCommand = _mapper.Map<SaveClientPropertyCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public async Task<IEnumerable<ClaimViewModel>> GetClaims(string clientId)
        {
            return _mapper.Map<IEnumerable<ClaimViewModel>>(await _clientRepository.GetClaims(clientId));
        }

        public Task<bool> RemoveClaim(RemoveClientClaimViewModel model)
        {
            var registerCommand = _mapper.Map<RemoveClientClaimCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public Task<bool> SaveClaim(SaveClientClaimViewModel model)
        {
            var registerCommand = _mapper.Map<SaveClientClaimCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public Task<bool> Save(SaveClientViewModel client)
        {
            var command = _mapper.Map<SaveClientCommand>(client);
            return Bus.SendCommand(command);
        }

        public Task<bool> Remove(RemoveClientViewModel client)
        {
            var command = _mapper.Map<RemoveClientCommand>(client);
            return Bus.SendCommand(command);
        }

        public Task<bool> Copy(CopyClientViewModel client)
        {
            var command = _mapper.Map<CopyClientCommand>(client);
            return Bus.SendCommand(command);
        }

        public async Task<Client> GetClientDefaultDetails(string clientId)
        {
            var resultado = await _clientRepository.GetClientDefaultDetails(clientId);
            return _mapper.Map<Client>(resultado);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}