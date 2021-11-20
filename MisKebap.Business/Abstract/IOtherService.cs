using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MisKebap.DAL.Dtos.Other;

namespace MisKebap.Business.Abstract
{
    public interface IOtherService
    {
        Task<int> UpdateAboutUs(AboutUsUpdateDto aboutUsUpdateDto);
        Task<AboutUsViewDto> AboutUsGet(int id);

        Task<int> WriteUsAdd(WriteUsAddDto writeUsAddDto);
        Task<int> WriteUsUpdate(WriteUsUpdateDto writeUsUpdateDto);
        Task<List<WriteUsViewDto>> WriteUsGetAll(bool IsRead);
        Task<WriteUsViewDto> WriteUsGet(int id);

        Task<int> UpdateSettings(SettingsUpdateDto settingsUpdateDto);
        Task<SettingsViewDto> GetSettings(int id);
    }
}
