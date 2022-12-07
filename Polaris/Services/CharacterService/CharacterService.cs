using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polaris.Data;
using Polaris.Dtos.Character;
using Polaris.Models;

namespace Polaris.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._mapper = mapper;
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(this._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharactersAsync()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var characters = await this._context.Characters.Where(x => x.User.Id.Equals(this.GetUserId())).ToListAsync();
            serviceResponse.Data = this._mapper.Map<List<GetCharacterDto>>(characters);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByIdAsync(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var result = await this._context.Characters.FirstOrDefaultAsync(x => x.Id.Equals(id));
            serviceResponse.Data = this._mapper.Map<GetCharacterDto>(result);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacterAsync(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dto = this._mapper.Map<Character>(newCharacter);
            this._context.Characters.Add(dto);
            await this._context.SaveChangesAsync();

            var characters = await this._context.Characters
                    .Select(x => this._mapper.Map<GetCharacterDto>(x))
                    .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = await this._context.Characters.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (character == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = $"Id({id}) does not exitst.";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            this._mapper.Map(updatedCharacter, character);
            await this._context.SaveChangesAsync();

            serviceResponse.Data = this._mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = await this._context.Characters.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (character == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = $"Id({id}) does not exitst.";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            this._context.Characters.Remove(character);
            await this._context.SaveChangesAsync();

            serviceResponse.Data = await this._context.Characters.Select(x => this._mapper.Map<GetCharacterDto>(x)).ToListAsync();
            return serviceResponse;
        }
    }
}
