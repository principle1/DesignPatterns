
using Principle.DesingPatterns.Creational;
using Principle.DesingPatterns.Structural;
using Principle.DesingPatterns.Behavioral;
using Principle.Models;



static void SingletonDemo() {
    Console.WriteLine("========== Singleton ==========");
    CompanyDirectorGeneral.Instance.ApproveProject();
}
static void BuilderDemo() {
    Console.WriteLine("========== Builder ==========");
    ArchitectDirector architectDirector = new();
    Hospital hospital = architectDirector.Build(new ConstructionForeman());
    Console.WriteLine(hospital);
}
static void FactoryMethodDemo() {
    Console.WriteLine("========== Factory Method ==========");
    TeamFactory teamFactory = new GeneralTeamFactory();
    ConstructionTeam team = teamFactory.CreateConstructionTeam();
    team.StartWorking();
    teamFactory = new SpecializedTeamFactory();
    team = teamFactory.CreateConstructionTeam();
    team.StartWorking();
}
static void AbstractFactoryDemo() {
    Console.WriteLine("========== Abstract Factory ==========");
    IProjectTeamFactory projectTeamFactory = new HospitalProjectTeamFactory();
    SiteEngineer engineer = projectTeamFactory.CreateEngineer();
    SiteSupervisor supervisor = projectTeamFactory.CreateSupervisor();
    engineer.Work();
    supervisor.Supervise();
}
static void PrototypeDemo() {
    Console.WriteLine("========== Prototype ==========");
    HospitalBlueprint blueprint = new() {
        HospitalName = "Central Hospital",
        FloorsCount = 8,
        Location = "Zagazig"
    };
    HospitalBlueprint copiedBlueprint = blueprint.DeepClone();
    Console.WriteLine(blueprint);
    Console.WriteLine(copiedBlueprint);
}
static void AdapterDemo() {
    Console.WriteLine("========== Adapter ==========");
    LegacyHospitalSystem legacySystem = new();
    IAccountingSystem accountingSystem = new AccountingAdapter(legacySystem);
    accountingSystem.GenerateInvoice();
}
static void BridgeDemo() {
    Console.WriteLine("========== Bridge ==========");
    ConstructionBridge bridge = new HospitalConstructionBridge(new ConcreteConstruction());
    bridge.Execute();
    bridge = new HospitalConstructionBridge(new SteelConstruction());
    bridge.Execute();
}
static void CompositeDemo() {
    Console.WriteLine("========== Composite ==========");
    HospitalComposite hospital = new("Central Hospital");
    BuildingFloor firstFloor = new("First Floor");
    firstFloor.Add(new DepartmentLeaf("Emergency"));
    firstFloor.Add(new DepartmentLeaf("Radiology"));
    BuildingFloor secondFloor = new("Second Floor");
    secondFloor.Add(new DepartmentLeaf("ICU"));
    secondFloor.Add(new DepartmentLeaf("Operating Rooms"));
    hospital.Add(firstFloor);
    hospital.Add(secondFloor);
    hospital.Display();
}
static void DecoratorDemo() {
    Console.WriteLine("========== Decorator ==========");
    IBuilding building = new FinishingDecorator(new BaseBuilding());
    building.Build();
}
static void FacadeDemo() {
    Console.WriteLine("========== Facade ==========");
    HospitalConstructionBridge bridge = new(new ConcreteConstruction());
    HospitalComposite composite = new("Central Hospital");
    composite.Add(new DepartmentLeaf("Emergency"));
    composite.Add(new DepartmentLeaf("Operating Rooms"));
    IBuilding building = new FinishingDecorator(new BaseBuilding());
    ClientServiceFacade facade = new(bridge, composite, building);
    facade.StartProject();
}
static void FlyweightDemo() {
    Console.WriteLine("========== Flyweight ==========");
    MaterialFlyweight flyweight = new();
    flyweight.GetMaterial("Concrete").Use("Foundation");
    flyweight.GetMaterial("Concrete").Use("Walls");
    flyweight.GetMaterial("Steel").Use("Roof");
    flyweight.ShowStatistics();
}
static void ProxyDemo() {
    Console.WriteLine("========== Proxy ==========");
    IProjectAccess proxy = new SecurityProxy(employeeName: "Waleed", hasPermission: true);
    proxy.StartProject();
}
static void MediatorDemo() {
    Console.WriteLine("========== Mediator ==========");
    DepartmentHub hub = new();
    OperatingRoomDept operatingRoom = new(hub);
    EmergencyDept emergency = new(hub);
    PharmacyDept pharmacy = new(hub);
    hub.Register(operatingRoom);
    hub.Register(emergency);
    hub.Register(pharmacy);
    operatingRoom.Send("Need Blood Units");
    pharmacy.Send("Medicines Ready");
}
static void ChainOfResponsibilityDemo() {
    Console.WriteLine("========== Chain Of Responsibility ==========");
    EngineerApprover engineer = new();
    ProjectManagerApprover manager = new();
    GeneralManagerApprover generalManager = new();
    engineer.SetNext(manager);
    manager.SetNext(generalManager);
    engineer.Approve(new PurchaseRequest("MRI Machine", 150000));
}
static void CommandDemo() {
    Console.WriteLine("========== Command ==========");
    ConstructionInvoker invoker = new();
    invoker.Add(new InstallElectricalCommand(new ElectricalTeam()));
    invoker.Add(new InstallPlumbingCommand(new PlumbingTeam()));
    invoker.Add(new InstallAirConditioningCommand(new AirConditioningTeam()));
    invoker.Execute();
}
static void InterpreterDemo() {
    Console.WriteLine("========== Interpreter ==========");
    ConstructionContext context = new() {
        HasBuildingPermit = true,
        HasSafetyApproval = true,
        HasBudgetApproval = true
    };
    PermitInterpreter interpreter = new();
    interpreter.Add(new BuildingPermitExpression());
    interpreter.Add(new SafetyApprovalExpression());
    interpreter.Add(new BudgetApprovalExpression());
    Console.WriteLine(interpreter.Validate(context));
}
static void IteratorDemo() {
    Console.WriteLine("========== Iterator ==========");
    DepartmentCollection departments = new();
    departments.Add("Emergency");
    departments.Add("ICU");
    departments.Add("Radiology");
    departments.Add("Operating Rooms");
    foreach (string department in departments)
        Console.WriteLine(department);
}
static void MementoDemo() {
    Console.WriteLine("========== Memento ==========");
    ConstructionProject project = new();
    ProjectArchive archive = new();
    project.Update("Foundation", 20);
    archive.Backup(project);
    project.Update("Walls", 45);
    archive.Backup(project);
    project.Update("Roof", 80);
    archive.Undo(project);
    Console.WriteLine($"{project.Phase} {project.Progress}%");
}
static void ObserverDemo() {
    Console.WriteLine("========== Observer ==========");
    ProjectNotifier notifier = new();
    notifier.Register(new EmergencyObserver());
    notifier.Register(new OperatingRoomObserver());
    notifier.Register(new MaintenanceObserver());
    notifier.SetStatus("Construction Completed");
}
static void StateDemo() {
    Console.WriteLine("========== State ==========");
    ProjectStateContext context = new(new DesignState());
    context.Next();
    context.Next();
    context.Next();
    context.Next();
}
static void StrategyDemo() {
    Console.WriteLine("========== Strategy ==========");
    ConstructionPlanner planner = new(new TraditionalConstructionStrategy());
    planner.Execute();
    planner.ChangeStrategy(new FastTrackConstructionStrategy());
    planner.Execute();
    planner.ChangeStrategy(new CostSavingConstructionStrategy());
    planner.Execute();
}
static void TemplateMethodDemo() {
    Console.WriteLine("========== Template Method ==========");
    ProjectWorkflow workflow = new HospitalProjectTemplate();
    workflow.ExecuteProject();
}
static void VisitorDemo() {
    Console.WriteLine("========== Visitor ==========");
    InspectionVisitor visitor = new();
    List<IInspectable> elements = new() {
        new Room("Room 101"),
        new OperatingRoom("OR-1"),
        new EmergencyUnit("Emergency")
    };
    foreach (IInspectable element in elements)
        element.Accept(visitor);
}


// ── يوم 1: وصول العميل وبدء التخطيط ──────────────────
SingletonDemo();          // المدير العام يعتمد المشروع أولاً
BuilderDemo();            // المهندس المعماري + رئيس فريق البناء
FactoryMethodDemo();      // توزيع فرق العمل
AbstractFactoryDemo();    // التوريدات المتكاملة
PrototypeDemo();          // نسخ المخططات

// ── يوم 2: بدء التنفيذ وحل المشاكل ──────────────────
AdapterDemo();            // ربط المعدات القديمة بالجديدة
BridgeDemo();             // فصل التصميم عن التنفيذ
CompositeDemo();          // تنظيم هيكل المبنى
DecoratorDemo();          // التشطيبات
FacadeDemo();             // موظف خدمة العملاء ينسق الكل
FlyweightDemo();          // تحسين الموارد المشتركة
ProxyDemo();              // رجل الأمن عند البوابة

// ── يوم 3: تطبيق اللوائح والسياسات ──────────────────
MediatorDemo();             // (ربط الأقسام ببعض أولاً (قبل ما يبدأ العمل اليومي
ChainOfResponsibilityDemo(); // مسار الصلاحيات لطلبات الشراء
CommandDemo();            // سجل توثيق العمليات اليومية
InterpreterDemo();        // معالجة تعليمات المخططات
StateDemo();              // حالة المشروع تتقدم
ObserverDemo();           // إخطار الأقسام بالتغييرات
MementoDemo();            // حفظ لقطة قبل أي تعديل كبير
IteratorDemo();           // الفحص الدوري في نهاية اليوم
StrategyDemo();           // اختيار منهجية التنفيذ
TemplateMethodDemo();     // نموذج العمل القياسي
VisitorDemo();            // مفتش الجودة الخارجي آخر خطوة




Console.WriteLine();
Console.WriteLine("========== END ==========");