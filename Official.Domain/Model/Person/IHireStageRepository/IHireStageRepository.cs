﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Person.IHireStageRepository
{
    public interface IHireStageRepository
    {
        Task<HireStage> Create(HireStage educationalInfo);
        Task<HireStage> Update(HireStage educationalInfo);
        Task Remove(long id);
        Task<HireStage> GetById(long id);
    }
}