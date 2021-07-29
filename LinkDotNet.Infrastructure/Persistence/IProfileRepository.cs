﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LinkDotNet.Domain;

namespace LinkDotNet.Infrastructure.Persistence
{
    public interface IProfileRepository
    {
        Task<IList<ProfileInformationEntry>> GetAllAsync();

        Task StoreAsync(ProfileInformationEntry entry);

        Task DeleteAsync(string id);
    }
}