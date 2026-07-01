namespace Principle.DesingPatterns.Structural {

    #region Adapter - مهندس الربط والتهيئة
    public class LegacyHospitalSystem {
        public void CreateHospitalInvoice() {
            Console.WriteLine("النظام القديم أنشأ فاتورة المشروع.");
        }
    }
    public interface IAccountingSystem {
        void GenerateInvoice();
    }
    public class AccountingAdapter : IAccountingSystem {
        private readonly LegacyHospitalSystem legacyHospitalSystem;
        public AccountingAdapter(LegacyHospitalSystem legacyHospitalSystem) {
            this.legacyHospitalSystem = legacyHospitalSystem;
        }
        public void GenerateInvoice() {
            Console.WriteLine("تحويل طلب النظام الجديد.");
            legacyHospitalSystem.CreateHospitalInvoice();
            Console.WriteLine("تم إنشاء الفاتورة.");
        }
    }
    //==================================================================
    #endregion

    #region Bridge - مهندس الفصل التقني
    public interface IConstructionMethod {
        void Build();
    }
    public class ConcreteConstruction : IConstructionMethod {
        public void Build() {
            Console.WriteLine("تنفيذ البناء الخرساني.");
        }
    }
    public class SteelConstruction : IConstructionMethod {
        public void Build() {
            Console.WriteLine("تنفيذ البناء المعدني.");
        }
    }
    public abstract class ConstructionBridge {
        protected readonly IConstructionMethod constructionMethod;
        protected ConstructionBridge(IConstructionMethod constructionMethod) {
            this.constructionMethod = constructionMethod;
        }
        public abstract void Execute();
    }
    public class HospitalConstructionBridge : ConstructionBridge {
        public HospitalConstructionBridge(IConstructionMethod constructionMethod)
            : base(constructionMethod) {
        }
        public override void Execute() {
            Console.WriteLine("اختيار أسلوب البناء.");
            constructionMethod.Build();
            Console.WriteLine("تم التنفيذ.");
        }
    }
    //==================================================================
    #endregion

    #region Composite - مهندس التكامل الهندسي
    public interface IBuildingComponent {
        void Display(int level = 0);
    }
    public class DepartmentLeaf : IBuildingComponent {
        public string Name { get; }
        public DepartmentLeaf(string name) {
            Name = name;
        }
        public void Display(int level = 0) {
            Console.WriteLine($"{new string(' ', level * 4)} {Name}");
        }
    }
    public class BuildingFloor : IBuildingComponent {
        private readonly List<IBuildingComponent> components = new();
        public string Name { get; }
        public BuildingFloor(string name) {
            Name = name;
        }
        public void Add(IBuildingComponent component) {
            components.Add(component);
        }
        public void Display(int level = 0) {
            Console.WriteLine($"{new string(' ', level * 4)} {Name}");
            foreach (IBuildingComponent component in components)
                component.Display(level + 1);
        }
    }
    public class HospitalComposite : IBuildingComponent {
        private readonly List<IBuildingComponent> components = new();
        public string Name { get; }
        public HospitalComposite(string name) {
            Name = name;
        }
        public void Add(IBuildingComponent component) {
            components.Add(component);
        }
        public void Display(int level = 0) {
            Console.WriteLine($" {Name}");
            foreach (IBuildingComponent component in components)
                component.Display(level + 1);
        }
    }
    //==================================================================
    #endregion

    #region Decorator - مهندس التشطيبات
    public interface IBuilding {
        void Build();
    }
    public class BaseBuilding : IBuilding {
        public void Build() {
            Console.WriteLine("تم الانتهاء من الهيكل الخرساني.");
        }
    }
    public abstract class BuildingDecorator : IBuilding {
        protected readonly IBuilding building;
        protected BuildingDecorator(IBuilding building) {
            this.building = building;
        }
        public virtual void Build() {
            building.Build();
        }
    }
    public class FinishingDecorator : BuildingDecorator {
        public FinishingDecorator(IBuilding building) : base(building) {
        }
        public override void Build() {
            base.Build();
            Console.WriteLine("بدء أعمال التشطيبات.");
            Console.WriteLine("تركيب أرضيات مضادة للبكتيريا.");
            Console.WriteLine("تركيب أبواب مقاومة للحريق.");
            Console.WriteLine("تنفيذ الدهانات الطبية.");
            Console.WriteLine("انتهت أعمال التشطيبات.");
        }
    }
    //==================================================================
    #endregion

    #region Facade - موظف خدمة العملاء
    public class ClientServiceFacade {
        private readonly HospitalConstructionBridge constructionBridge;
        private readonly HospitalComposite buildingComposite;
        private readonly IBuilding building;
        public ClientServiceFacade(HospitalConstructionBridge constructionBridge,
            HospitalComposite buildingComposite, IBuilding building) {
            this.constructionBridge = constructionBridge;
            this.buildingComposite = buildingComposite;
            this.building = building;
        }
        public void StartProject() {
            Console.WriteLine("بدأ تنفيذ مشروع المستشفى.");
            constructionBridge.Execute();
            buildingComposite.Display();
            building.Build();
            Console.WriteLine("تم الانتهاء من المشروع.");
        }
    }
    //==================================================================
    #endregion

    #region Flyweight - مهندس تحسين الموارد المشتركة
    public class SharedMaterial {
        public string Name { get; }
        public SharedMaterial(string name) {
            Name = name;
            Console.WriteLine($"إنشاء مادة : {name}");
        }
        public void Use(string location) {
            Console.WriteLine($"استخدام {Name} داخل {location}");
        }
    }
    public class MaterialFlyweight {
        private readonly Dictionary<string, SharedMaterial> materials = new();
        public SharedMaterial GetMaterial(string materialName) {
            if (!materials.ContainsKey(materialName))
                materials.Add(materialName, new SharedMaterial(materialName));
            return materials[materialName];
        }
        public void ShowStatistics() {
            Console.WriteLine($"عدد المواد المشتركة : {materials.Count}");
        }
    }
    //==================================================================
    #endregion

    #region Proxy - رجل الأمن
    public interface IProjectAccess {
        void StartProject();
    }
    public class RealProject : IProjectAccess {
        public void StartProject() {
            Console.WriteLine("بدأ تنفيذ المشروع.");
        }
    }
    public class SecurityProxy : IProjectAccess {
        private readonly RealProject realProject = new();
        public bool HasPermission { get; set; }
        public string EmployeeName { get; }
        public SecurityProxy(string employeeName, bool hasPermission) {
            EmployeeName = employeeName;
            HasPermission = hasPermission;
        }
        public void StartProject() {
            Console.WriteLine($"التحقق من صلاحيات {EmployeeName}");
            if (!HasPermission) {
                Console.WriteLine("تم رفض الدخول.");
                return;
            }
            Console.WriteLine("تم السماح بالدخول.");
            realProject.StartProject();
        }
    }
    //==================================================================
    #endregion
}