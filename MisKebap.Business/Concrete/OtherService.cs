using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Context;
using MisKebap.DAL.Dtos.Other;
using MisKebap.DAL.Entities;

namespace MisKebap.Business.Concrete
{
    public class OtherService : IOtherService
    {
        private readonly MisKebapContext _misKebapContext;

        public OtherService(MisKebapContext misKebapContext)
        {
            _misKebapContext = misKebapContext;
        }

        public Task<AboutUsViewDto> AboutUsGet(int id)
        {
            return _misKebapContext.AboutUs.Where(q => !q.IsDeleted)
                .Select(q => new AboutUsViewDto
                {
                    Id = q.Id,
                    Title = q.Title,
                }).FirstOrDefaultAsync(q => q.Id == id);
        }

        public Task<SettingsViewDto> GetSettings(int id)
        {
            return _misKebapContext.Settings.Where(q => !q.IsDeleted)
             .Select(q => new SettingsViewDto
             {
                 Id = q.Id,
                 Title = q.Title,
                 IsOpen = q.IsOpen,

             }).FirstOrDefaultAsync(q => q.Id == id);
        }

        public Task<int> UpdateAboutUs(AboutUsUpdateDto aboutUsUpdateDto)
        {
            var result = _misKebapContext.AboutUs.FirstOrDefault(q => !q.IsDeleted && q.Id == aboutUsUpdateDto.Id);
            if (result == null) return Task.FromResult(-1);

            result.Title = aboutUsUpdateDto.Title;
            _misKebapContext.AboutUs.Update(result);
            return _misKebapContext.SaveChangesAsync();
        }

        public Task<int> UpdateSettings(SettingsUpdateDto settingsUpdateDto)
        {
            var result = _misKebapContext.Settings.FirstOrDefault(q => !q.IsDeleted && q.Id == settingsUpdateDto.Id);
            if (result == null) return Task.FromResult(-1);

            result.Title = settingsUpdateDto.Title;
            result.IsOpen = settingsUpdateDto.IsOpen;

            _misKebapContext.Settings.Update(result);
            return _misKebapContext.SaveChangesAsync();
        }

        public Task<int> WriteUsAdd(WriteUsAddDto writeUsAddDto)
        {
            var write = new WriteUs
            {
                NameSurname = writeUsAddDto.NameSurname,
                Phone = writeUsAddDto.Phone,
                Message = writeUsAddDto.Message,
                IsRead = false
            };

            _misKebapContext.WriteUs.Add(write);
            var result = _misKebapContext.SaveChangesAsync();

            return result;
        }

        public Task<WriteUsViewDto> WriteUsGet(int id)
        {
            return _misKebapContext.WriteUs.Where(q => !q.IsDeleted)
                .Select(q => new WriteUsViewDto
                {
                    Id = q.Id,
                    NameSurname = q.NameSurname,
                    Phone = q.Phone,
                    Message = q.Message,
                    IsRead = q.IsRead

                }).FirstOrDefaultAsync(q => q.Id == id);
        }

        public Task<List<WriteUsViewDto>> WriteUsGetAll(bool IsRead)
        {
            if(IsRead == false)
            {
                return _misKebapContext.WriteUs.Where(q => !q.IsDeleted && q.IsRead == false)
                 .Select(q => new WriteUsViewDto
                 {
                     Id = q.Id,
                     NameSurname = q.NameSurname,
                     Phone = q.Phone,
                     Message = q.Message,
                     IsRead = q.IsRead

                 }).ToListAsync();
            }
            else 
            {
                return _misKebapContext.WriteUs.Where(q => !q.IsDeleted && q.IsRead == true)
                   .Select(q => new WriteUsViewDto
                   {
                       Id = q.Id,
                       NameSurname = q.NameSurname,
                       Phone = q.Phone,
                       Message = q.Message,
                       IsRead = q.IsRead

                   }).ToListAsync();

            }
            
        }

        public Task<int> WriteUsUpdate(WriteUsUpdateDto writeUsUpdateDto)
        {
            var result = _misKebapContext.WriteUs.FirstOrDefault(q => !q.IsDeleted && q.Id == writeUsUpdateDto.Id);
            if (result == null) return Task.FromResult(-1);

            result.IsRead = writeUsUpdateDto.IsRead;

            _misKebapContext.WriteUs.Update(result);
            return _misKebapContext.SaveChangesAsync();
        }
    }
}
