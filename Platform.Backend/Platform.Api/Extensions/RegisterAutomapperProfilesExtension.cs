using Platform.Core.MapperProfiles;

namespace Platform.Api.Extensions
{
    public static class RegisterAutomapperProfilesExtension
    {
        public static void RegisterAutomapperProfiles(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ProgramProfile));
            service.AddAutoMapper(typeof(StudentProfile));
            service.AddAutoMapper(typeof(CommentProfile));
            service.AddAutoMapper(typeof(SelectionProfile));
            service.AddAutoMapper(typeof(UserProfile));
            service.AddAutoMapper(typeof(UserRoleProfile));
            service.AddAutoMapper(typeof(RoleProfile));
            service.AddAutoMapper(typeof(ItemProfile));
            service.AddAutoMapper(typeof(ItemProgramProfile));
            service.AddAutoMapper(typeof(ItemStudentProfile));
        }
    }
}
