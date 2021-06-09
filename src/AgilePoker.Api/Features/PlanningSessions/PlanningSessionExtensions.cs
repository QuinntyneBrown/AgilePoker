using System;
using AgilePoker.Api.Models;

namespace AgilePoker.Api.Features
{
    public static class PlanningSessionExtensions
    {
        public static PlanningSessionDto ToDto(this PlanningSession planningSession)
        {
            return new ()
            {
                PlanningSessionId = planningSession.PlanningSessionId
            };
        }
        
    }
}
