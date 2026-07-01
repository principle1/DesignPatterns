using System.Collections;
namespace Principle.DesingPatterns.Behavioral {

    #region Chain Of Responsibility - مسار الصلاحيات
    public class PurchaseRequest {
        public string ItemName { get; }
        public decimal Price { get; }
        public PurchaseRequest(string itemName, decimal price) {
            ItemName = itemName;
            Price = price;
        }
    }
    public abstract class ApprovalHandler {
        protected ApprovalHandler? nextHandler;
        public void SetNext(ApprovalHandler nextHandler) {
            this.nextHandler = nextHandler;
        }
        public abstract void Approve(PurchaseRequest purchaseRequest);
    }
    public class EngineerApprover : ApprovalHandler {
        public override void Approve(PurchaseRequest purchaseRequest) {
            if (purchaseRequest.Price <= 10000) {
                Console.WriteLine($"المهندس وافق على {purchaseRequest.ItemName}");
                return;
            }
            nextHandler?.Approve(purchaseRequest);
        }
    }
    public class ProjectManagerApprover : ApprovalHandler {
        public override void Approve(PurchaseRequest purchaseRequest) {
            if (purchaseRequest.Price <= 50000) {
                Console.WriteLine($"مدير المشروع وافق على {purchaseRequest.ItemName}");
                return;
            }
            nextHandler?.Approve(purchaseRequest);
        }
    }
    public class GeneralManagerApprover : ApprovalHandler {
        public override void Approve(PurchaseRequest purchaseRequest) {
            Console.WriteLine($"المدير التنفيذي وافق على {purchaseRequest.ItemName}");
        }
    }
    //==================================================================
    #endregion

    #region Mediator - سياسة ربط الأقسام
    public abstract class OfficeMediator {
        public abstract void Send(string message, OfficeDept sender);
    }
    public class OfficeDept {
        protected readonly OfficeMediator mediator;
        public string Name { get; }
        public OfficeDept(OfficeMediator mediator, string name) {
            this.mediator = mediator;
            Name = name;
        }
        public void Send(string message) {
            mediator.Send(message, this);
        }
        public virtual void Receive(string message) {
            Console.WriteLine($"{Name} : {message}");
        }
    }
    public class OperatingRoomDept : OfficeDept {
        public OperatingRoomDept(OfficeMediator mediator) : base(mediator, "Operating Rooms") {
        }
    }
    public class EmergencyDept : OfficeDept {
        public EmergencyDept(OfficeMediator mediator) : base(mediator, "Emergency") {
        }
    }
    public class PharmacyDept : OfficeDept {
        public PharmacyDept(OfficeMediator mediator) : base(mediator, "Pharmacy") {
        }
    }
    public class DepartmentHub : OfficeMediator {
        private readonly List<OfficeDept> departments = new();
        public void Register(OfficeDept department) {
            departments.Add(department);
        }
        public override void Send(string message, OfficeDept sender) {
            foreach (OfficeDept department in departments)
                if (department != sender)
                    department.Receive(message);
        }
    }
    //==================================================================
    #endregion

    #region Command - سجل توثيق العمليات
    public interface IWorkCommand {
        void Execute();
    }
    public class ElectricalTeam {
        public void Install() {
            Console.WriteLine("تنفيذ شبكة الكهرباء.");
        }
    }
    public class PlumbingTeam {
        public void Install() {
            Console.WriteLine("تنفيذ شبكة المياه.");
        }
    }
    public class AirConditioningTeam {
        public void Install() {
            Console.WriteLine("تركيب التكييف.");
        }
    }
    public class InstallElectricalCommand : IWorkCommand {
        private readonly ElectricalTeam electricalTeam;
        public InstallElectricalCommand(ElectricalTeam electricalTeam) {
            this.electricalTeam = electricalTeam;
        }
        public void Execute() {
            electricalTeam.Install();
        }
    }
    public class InstallPlumbingCommand : IWorkCommand {
        private readonly PlumbingTeam plumbingTeam;
        public InstallPlumbingCommand(PlumbingTeam plumbingTeam) {
            this.plumbingTeam = plumbingTeam;
        }
        public void Execute() {
            plumbingTeam.Install();
        }
    }
    public class InstallAirConditioningCommand : IWorkCommand {
        private readonly AirConditioningTeam airConditioningTeam;
        public InstallAirConditioningCommand(AirConditioningTeam airConditioningTeam) {
            this.airConditioningTeam = airConditioningTeam;
        }
        public void Execute() {
            airConditioningTeam.Install();
        }
    }
    public class ConstructionInvoker {
        private readonly List<IWorkCommand> commands = new();
        public void Add(IWorkCommand command) {
            commands.Add(command);
        }
        public void Execute() {
            foreach (IWorkCommand command in commands)
                command.Execute();
        }
    }
    //==================================================================
    #endregion

    #region Interpreter - سياسة معالجة البيانات
    public class ConstructionContext {
        public bool HasBuildingPermit { get; set; }
        public bool HasSafetyApproval { get; set; }
        public bool HasBudgetApproval { get; set; }
    }
    public interface IConstructionExpression {
        bool Interpret(ConstructionContext context);
    }
    public class BuildingPermitExpression : IConstructionExpression {
        public bool Interpret(ConstructionContext context) {
            return context.HasBuildingPermit;
        }
    }
    public class SafetyApprovalExpression : IConstructionExpression {
        public bool Interpret(ConstructionContext context) {
            return context.HasSafetyApproval;
        }
    }
    public class BudgetApprovalExpression : IConstructionExpression {
        public bool Interpret(ConstructionContext context) {
            return context.HasBudgetApproval;
        }
    }
    public class PermitInterpreter {
        private readonly List<IConstructionExpression> expressions = new();
        public void Add(IConstructionExpression expression) {
            expressions.Add(expression);
        }
        public bool Validate(ConstructionContext context) {
            return expressions.All(x => x.Interpret(context));
        }
    }
    //==================================================================
    #endregion

    #region Iterator - سياسة الفحص الدوري
    public class DepartmentCollection : IEnumerable<string> {
        private readonly List<string> departments = new();
        public void Add(string departmentName) {
            departments.Add(departmentName);
        }
        public IEnumerator<string> GetEnumerator() {
            return new DepartmentIterator(departments);
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
    public class DepartmentIterator : IEnumerator<string> {
        private readonly List<string> departments;
        private int currentIndex = -1;
        public DepartmentIterator(List<string> departments) {
            this.departments = departments;
        }
        public string Current => departments[currentIndex];
        object IEnumerator.Current => Current;
        public bool MoveNext() {
            currentIndex++;
            return currentIndex < departments.Count;
        }
        public void Reset() {
            currentIndex = -1;
        }
        public void Dispose() {
        }
    }
    //==================================================================
    #endregion

    #region Memento - سياسة الاستعادة والطوارئ
    public class ProjectSnapshot {
        public string Phase { get; }
        public int Progress { get; }
        public ProjectSnapshot(string phase, int progress) {
            Phase = phase;
            Progress = progress;
        }
    }
    public class ConstructionProject {
        public string Phase { get; private set; } = "";
        public int Progress { get; private set; }
        public void Update(string phase, int progress) {
            Phase = phase;
            Progress = progress;
        }
        public ProjectSnapshot Save() {
            return new ProjectSnapshot(Phase, Progress);
        }
        public void Restore(ProjectSnapshot snapshot) {
            Phase = snapshot.Phase;
            Progress = snapshot.Progress;
        }
    }
    public class ProjectArchive {
        private readonly Stack<ProjectSnapshot> snapshots = new();
        public void Backup(ConstructionProject project) {
            snapshots.Push(project.Save());
        }
        public void Undo(ConstructionProject project) {
            if (snapshots.Count > 0)
                project.Restore(snapshots.Pop());
        }
    }
    //==================================================================
    #endregion

    #region Observer - نظام التنبيهات المركزية
    public interface IProjectObserver {
        void Update(string projectStatus);
    }
    public interface IProjectSubject {
        void Register(IProjectObserver observer);
        void Remove(IProjectObserver observer);
        void Notify();
    }
    public class ProjectNotifier : IProjectSubject {
        private readonly List<IProjectObserver> observers = new();
        private string projectStatus = string.Empty;
        public void Register(IProjectObserver observer) {
            observers.Add(observer);
        }
        public void Remove(IProjectObserver observer) {
            observers.Remove(observer);
        }
        public void SetStatus(string projectStatus) {
            this.projectStatus = projectStatus;
            Notify();
        }
        public void Notify() {
            foreach (IProjectObserver observer in observers)
                observer.Update(projectStatus);
        }
    }
    public class EmergencyObserver : IProjectObserver {
        public void Update(string projectStatus) {
            Console.WriteLine($"Emergency : {projectStatus}");
        }
    }
    public class OperatingRoomObserver : IProjectObserver {
        public void Update(string projectStatus) {
            Console.WriteLine($"Operating Rooms : {projectStatus}");
        }
    }
    public class MaintenanceObserver : IProjectObserver {
        public void Update(string projectStatus) {
            Console.WriteLine($"Maintenance : {projectStatus}");
        }
    }
    //==================================================================
    #endregion

    #region State - بروتوكول حالة العمل
    public interface IProjectState {
        void Handle(ProjectStateContext context);
    }
    public class DesignState : IProjectState {
        public void Handle(ProjectStateContext context) {
            Console.WriteLine("Design");
            context.SetState(new ConstructionState());
        }
    }
    public class ConstructionState : IProjectState {
        public void Handle(ProjectStateContext context) {
            Console.WriteLine("Construction");
            context.SetState(new FinishingState());
        }
    }
    public class FinishingState : IProjectState {
        public void Handle(ProjectStateContext context) {
            Console.WriteLine("Finishing");
            context.SetState(new CompletedState());
        }
    }
    public class CompletedState : IProjectState {
        public void Handle(ProjectStateContext context) {
            Console.WriteLine("Completed");
        }
    }
    public class ProjectStateContext {
        private IProjectState state;
        public ProjectStateContext(IProjectState state) {
            this.state = state;
        }
        public void SetState(IProjectState state) {
            this.state = state;
        }
        public void Next() {
            state.Handle(this);
        }
    }
    //==================================================================
    #endregion

    #region Strategy - سياسة اختيار منهجية العمل
    public interface IConstructionStrategy {
        void Execute();
    }
    public class TraditionalConstructionStrategy : IConstructionStrategy {
        public void Execute() {
            Console.WriteLine("Traditional Construction");
        }
    }
    public class FastTrackConstructionStrategy : IConstructionStrategy {
        public void Execute() {
            Console.WriteLine("Fast Track Construction");
        }
    }
    public class CostSavingConstructionStrategy : IConstructionStrategy {
        public void Execute() {
            Console.WriteLine("Cost Saving Construction");
        }
    }
    public class ConstructionPlanner {
        private IConstructionStrategy strategy;
        public ConstructionPlanner(IConstructionStrategy strategy) {
            this.strategy = strategy;
        }
        public void ChangeStrategy(IConstructionStrategy strategy) {
            this.strategy = strategy;
        }
        public void Execute() {
            strategy.Execute();
        }
    }
    //==================================================================
    #endregion

    #region Template Method - نموذج العمل القياسي
    public abstract class ProjectWorkflow {
        public void ExecuteProject() {
            ReceiveProject();
            DesignProject();
            BuildProject();
            FinishProject();
            DeliverProject();
        }
        protected virtual void ReceiveProject() {
            Console.WriteLine("Receive Project");
        }
        protected abstract void DesignProject();
        protected abstract void BuildProject();
        protected abstract void FinishProject();
        protected virtual void DeliverProject() {
            Console.WriteLine("Deliver Project");
        }
    }
    public class HospitalProjectTemplate : ProjectWorkflow {
        protected override void DesignProject() {
            Console.WriteLine("Design");
        }
        protected override void BuildProject() {
            Console.WriteLine("Build");
        }
        protected override void FinishProject() {
            Console.WriteLine("Finish");
        }
    }
    //==================================================================
    #endregion

    #region Visitor - بروتوكول التفتيش الخارجي
    public interface IInspectable {
        void Accept(IInspectionVisitor visitor);
    }
    public interface IInspectionVisitor {
        void Visit(Room room);
        void Visit(OperatingRoom operatingRoom);
        void Visit(EmergencyUnit emergencyUnit);
    }
    public class Room : IInspectable {
        public string Name { get; }
        public Room(string name) {
            Name = name;
        }
        public void Accept(IInspectionVisitor visitor) {
            visitor.Visit(this);
        }
    }
    public class OperatingRoom : IInspectable {
        public string Name { get; }
        public OperatingRoom(string name) {
            Name = name;
        }
        public void Accept(IInspectionVisitor visitor) {
            visitor.Visit(this);
        }
    }
    public class EmergencyUnit : IInspectable {
        public string Name { get; }
        public EmergencyUnit(string name) {
            Name = name;
        }
        public void Accept(IInspectionVisitor visitor) {
            visitor.Visit(this);
        }
    }
    public class InspectionVisitor : IInspectionVisitor {
        public void Visit(Room room) {
            Console.WriteLine($"Inspect {room.Name}");
        }
        public void Visit(OperatingRoom operatingRoom) {
            Console.WriteLine($"Inspect {operatingRoom.Name}");
        }
        public void Visit(EmergencyUnit emergencyUnit) {
            Console.WriteLine($"Inspect {emergencyUnit.Name}");
        }
    }
    //==================================================================
    #endregion
}