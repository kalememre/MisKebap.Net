using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Context;
using MisKebap.DAL.Dtos.NBH;
using MisKebap.DAL.Entities;

namespace MisKebap.Business.Concrete
{
    public class NBHService : INBHService
    {
        private readonly MisKebapContext _misKebapContext;

        public NBHService(MisKebapContext misKebapContext)
        {
            _misKebapContext = misKebapContext;
        }

        public Task<int> Add(NBHAddDto NBHAddDto)
        {
            var nbh = new NBH
            {
                Title = NBHAddDto.Title,
                Limit = NBHAddDto.Limit,
                IsEnabled = true
            };

            _misKebapContext.NBHs.Add(nbh);
            var result = _misKebapContext.SaveChangesAsync();

            return result;
        }

        public async Task<int> Delete(int id)
        {
            var currentNBH = await _misKebapContext.NBHs.Where(q => !q.IsDeleted && q.Id == id).FirstOrDefaultAsync();

            if (currentNBH == null)
            {
                return await Task.FromResult(-1);
            }
            else
            {
                var res = await _misKebapContext.CustomerAddresses.Where(q => !q.IsDeleted && q.NBHId == id).FirstOrDefaultAsync();
                if (res != null)
                {
                    return await Task.FromResult(-2);
                }
                else
                {
                    currentNBH.IsDeleted = true;
                    _misKebapContext.NBHs.Update(currentNBH);
                    await _misKebapContext.SaveChangesAsync();
                    return await Task.FromResult(1);
                }
            }

        }

        public Task<NBHViewDto> Get(int id)
        {
            return _misKebapContext.NBHs.Where(q => !q.IsDeleted)
                 .Select(q => new NBHViewDto
                 {
                     Id = q.Id,
                     Title = q.Title,
                     Limit = q.Limit,
                     IsEnabled = q.IsEnabled
                 }).FirstOrDefaultAsync(q => q.Id == id);
        }

        public Task<List<NBHViewDto>> GetAll()
        {
            return _misKebapContext.NBHs.Where(q => !q.IsDeleted)
                 .Select(q => new NBHViewDto
                 {
                     Id = q.Id,
                     Title = q.Title,
                     Limit = q.Limit,
                     IsEnabled = q.IsEnabled
                 }).ToListAsync();
        }

        public async Task<bool> IsUniqueTitle(string title)
        {
            var nbh = await _misKebapContext.NBHs.Where(q => !q.IsDeleted).Select(q => q.Title).ToListAsync();
            return !nbh.Contains(title);
        }

        public Task<int> Update(NBHUpdateDto NBHUpdateDto)
        {
            var item = _misKebapContext.NBHs.FirstOrDefault(q => !q.IsDeleted && q.Id == NBHUpdateDto.Id);

            if (item == null)
            {
                //guncellenecek mahalle bulunamadi
                return Task.FromResult(-1);
            }

            item.Title = NBHUpdateDto.Title;
            item.Limit = NBHUpdateDto.Limit;
            item.IsEnabled = NBHUpdateDto.IsEnabled;

            _misKebapContext.NBHs.Update(item);
            var result = _misKebapContext.SaveChangesAsync();

            return result;

        }
    }
}
