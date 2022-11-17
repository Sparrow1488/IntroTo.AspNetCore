using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace IntroTo.Auth.Policies.Requirements;

internal class MinimumAgeRequirements : IAuthorizationRequirement
{
    public MinimumAgeRequirements(int ageRequired)
    {
        AgeRequired = ageRequired;
    }

    public int AgeRequired { get; }
}

internal class MinimumAgeRequirementsHandler : AuthorizationHandler<MinimumAgeRequirements>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, MinimumAgeRequirements requirement)
    {
        var ageClaimValue = context.User.FindFirstValue("age") ?? "0";
        var age = int.Parse(ageClaimValue);
        if (age >= requirement.AgeRequired)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
        context.Fail();
        return Task.CompletedTask;
    }
}