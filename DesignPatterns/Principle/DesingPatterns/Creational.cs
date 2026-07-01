using Principle.Models;
namespace Principle.DesingPatterns.Creational {

    #region Singleton - المدير العام للشركة
    public sealed class CompanyDirectorGeneral {
        private static readonly Lazy<CompanyDirectorGeneral> instance =
            new(() => new CompanyDirectorGeneral());
        public static CompanyDirectorGeneral Instance => instance.Value;
        private CompanyDirectorGeneral() {
        }
        public void ApproveProject() {
            Console.WriteLine("المدير العام للشركة اعتمد المشروع.");
        }
    }
    //==================================================================
    #endregion

    #region Director - المهندس المعماري
    public class ArchitectDirector {
        public Hospital Build(ConstructionForeman foreman) {
            return foreman
                .BuildFoundation()
                .BuildWalls()
                .BuildRoof()
                .BuildOperatingRooms()
                .BuildEmergencyDepartment()
                .Build();
        }
    }
    //==================================================================
    #endregion

    #region Builder - رئيس فريق البناء
    public class ConstructionForeman {
        protected readonly Hospital hospital = new();
        public virtual ConstructionForeman BuildFoundation() {
            hospital.FoundationCompleted = true;
            return this;
        }
        public virtual ConstructionForeman BuildWalls() {
            hospital.WallsCompleted = true;
            return this;
        }
        public virtual ConstructionForeman BuildRoof() {
            hospital.RoofCompleted = true;
            return this;
        }
        public virtual ConstructionForeman BuildOperatingRooms() {
            hospital.OperatingRoomsCompleted = true;
            return this;
        }
        public virtual ConstructionForeman BuildEmergencyDepartment() {
            hospital.EmergencyDepartmentCompleted = true;
            return this;
        }
        public virtual Hospital Build() {
            return hospital;
        }
    }
    //==================================================================
    #endregion

    #region Factory Method - مهندس توزيع فرق العمل
    public abstract class ConstructionTeam {
        public abstract void StartWorking();
    }
    public class GeneralConstructionTeam : ConstructionTeam {
        public override void StartWorking() {
            Console.WriteLine("الفريق العام بدأ تنفيذ الهيكل الخرساني.");
        }
    }
    public class SpecializedConstructionTeam : ConstructionTeam {
        public override void StartWorking() {
            Console.WriteLine("الفريق المتخصص بدأ تجهيز غرف العمليات والطوارئ.");
        }
    }
    public abstract class TeamFactory {
        public abstract ConstructionTeam CreateConstructionTeam();
    }
    public class GeneralTeamFactory : TeamFactory {
        public override ConstructionTeam CreateConstructionTeam() {
            return new GeneralConstructionTeam();
        }
    }
    public class SpecializedTeamFactory : TeamFactory {
        public override ConstructionTeam CreateConstructionTeam() {
            return new SpecializedConstructionTeam();
        }
    }
    //==================================================================
    #endregion

    #region Abstract Factory - مهندس التوريدات المتكاملة
    public interface IProjectTeamFactory {
        SiteEngineer CreateEngineer();
        SiteSupervisor CreateSupervisor();
    }
    public class SiteEngineer {
        public void Work() {
            Console.WriteLine("المهندس بدأ إعداد الرسومات التنفيذية.");
        }
    }
    public class SiteSupervisor {
        public void Supervise() {
            Console.WriteLine("المشرف يتابع تنفيذ الأعمال بالموقع.");
        }
    }
    public class HospitalProjectTeamFactory : IProjectTeamFactory {
        public SiteEngineer CreateEngineer() {
            return new SiteEngineer();
        }
        public SiteSupervisor CreateSupervisor() {
            return new SiteSupervisor();
        }
    }
    //==================================================================
    #endregion

    #region Prototype - مهندس نسخ المخططات الهندسية
    public class HospitalBlueprint : ICloneable {
        public string HospitalName { get; set; }
        public int FloorsCount { get; set; }
        public string Location { get; set; }
        public object Clone() {
            return MemberwiseClone();
        }
        public HospitalBlueprint DeepClone() {
            return (HospitalBlueprint)MemberwiseClone();
        }
        public override string ToString() {
            return $"Hospital : {HospitalName} | Floors : {FloorsCount} | Location : {Location}";
        }
    }
    //==================================================================
    #endregion

}