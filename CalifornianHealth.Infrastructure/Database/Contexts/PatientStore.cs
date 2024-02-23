using CalifornianHealth.Infrastructure.Database.Contexts;
using CalifornianHealth.Infrastructure.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class PatientStore : IUserStore<Patient>
{
    private readonly IdentityContext _context;

    public PatientStore(IdentityContext context)
    {
        _context = context;
    }

    public async Task<IdentityResult> CreateAsync(Patient user, CancellationToken cancellationToken)
    {
        _context.Patients.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeleteAsync(Patient user, CancellationToken cancellationToken)
    {
        _context.Patients.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public async Task<Patient?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _context.Patients.FindAsync(new object[] { userId }, cancellationToken);
    }

    public async Task<Patient?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        return await _context.Patients
            //.AsAsyncEnumerable()
            .FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName, cancellationToken);
    }

    public Task<string?> GetNormalizedUserNameAsync(Patient user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.NormalizedUserName);
    }

    public Task<string> GetUserIdAsync(Patient user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Id.ToString());
    }

    public Task<string?> GetUserNameAsync(Patient user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName);
    }

    public Task SetNormalizedUserNameAsync(Patient user, string? normalizedName, CancellationToken cancellationToken)
    {
        user.NormalizedUserName = normalizedName;
        return Task.CompletedTask;
    }

    public Task SetUserNameAsync(Patient user, string? userName, CancellationToken cancellationToken)
    {
        user.UserName = userName;
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> UpdateAsync(Patient user, CancellationToken cancellationToken)
    {
        _context.Patients.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public void Dispose() { }
}
