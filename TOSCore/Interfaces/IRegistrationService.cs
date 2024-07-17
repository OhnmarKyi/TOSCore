using TOSCore.Context;

namespace TOSCore.Interfaces
{
    public interface IRegistrationService
    {
        public  Task<List<MBrand>> GetBrand();
    }
}
