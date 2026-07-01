<div dir="rtl">

# Design Patterns — Principle Construction

> مخطط يوضح تسلسل الـ 23 نمط وعلاقاتهم ببعض عبر مراحل المشروع الثلاث.
> كل مربع يحتوي: اسم الكلاس — اسم النمط — الاسم الأدبي من قصة الشركة.

```mermaid
flowchart TD

    Client([Client\nيطلب بناء المستشفى])

    %% ══════════════════════════════
    %%  مرحلة التأسيس — Creational
    %% ══════════════════════════════
    subgraph Creational["🏗 مرحلة التأسيس — Creational"]
        direction TB
        Singleton["CompanyDirectorGeneral\nSingleton\nالمدير العام للشركة"]
        Director["ArchitectDirector\nDirector\nالمهندس المعماري"]
        Builder["ConstructionForeman\nBuilder\nرئيس فريق البناء"]
        Factory["TeamFactory\nFactory Method\nمهندس توزيع الفرق"]
        AbstractFactory["HospitalProjectTeamFactory\nAbstract Factory\nمهندس التوريدات المتكاملة"]
        Prototype["HospitalBlueprint\nPrototype\nمهندس نسخ المخططات"]

        Singleton --> Director
        Singleton --> Builder
        Director  --> Factory
        Builder   --> AbstractFactory
        Builder   --> Prototype
    end

    %% ══════════════════════════════
    %%  مرحلة التنفيذ — Structural
    %% ══════════════════════════════
    subgraph Structural["🏛 مرحلة التنفيذ — Structural"]
        direction TB
        Adapter["AccountingAdapter\nAdapter\nمهندس الربط والتهيئة"]
        Bridge["HospitalConstructionBridge\nBridge\nمهندس الفصل التقني"]
        Composite["HospitalComposite\nComposite\nمهندس التكامل الهندسي"]
        Decorator["FinishingDecorator\nDecorator\nمهندس التشطيبات"]
        Flyweight["MaterialFlyweight\nFlyweight\nمهندس تحسين الموارد"]
        Facade["ClientServiceFacade\nFacade\nموظف خدمة العملاء"]
        Proxy["SecurityProxy\nProxy\nرجل الأمن"]

        Adapter   --> Composite
        Bridge    --> Decorator
        Bridge    --> Flyweight
        Composite --> Facade
        Decorator --> Facade
        Flyweight --> Facade
        Facade    --> Proxy
    end

    %% ══════════════════════════════
    %%  مرحلة التشغيل — Behavioral
    %% ══════════════════════════════
    subgraph Behavioral["⚙️ مرحلة التشغيل — Behavioral"]
        direction TB
        Mediator["DepartmentHub\nMediator\nسياسة ربط الأقسام"]
        Chain["ApprovalHandler\nChain of Responsibility\nمسار الصلاحيات"]
        Command["ConstructionInvoker\nCommand\nسجل توثيق العمليات"]
        Interpreter["PermitInterpreter\nInterpreter\nسياسة معالجة البيانات"]
        Observer["ProjectNotifier\nObserver\nنظام التنبيهات المركزية"]
        State["ProjectStateContext\nState\nبروتوكول حالة العمل"]
        Memento["ProjectArchive\nMemento\nسياسة الاستعادة والطوارئ"]
        Iterator["DepartmentIterator\nIterator\nسياسة الفحص الدوري"]
        Strategy["ConstructionPlanner\nStrategy\nسياسة اختيار المنهجية"]
        Template["ProjectWorkflow\nTemplate Method\nنموذج العمل القياسي"]
        Visitor["InspectionVisitor\nVisitor\nبروتوكول التفتيش الخارجي"]

        Mediator    --> Command
        Chain       --> Interpreter
        Chain       --> Observer
        Command     --> State
        Interpreter --> State
        Observer    --> Memento
        State       --> Iterator
        State       --> Strategy
        Memento     --> Template
        Iterator    --> Visitor
        Strategy    --> Visitor
        Template    --> Visitor
    end

    %% ══════════════════════════════
    %%  التسلسل الرئيسي
    %% ══════════════════════════════
    Client      --> Singleton
    Creational  --> Structural
    Structural  --> Behavioral

    %% ══════════════════════════════
    %%  ألوان المراحل
    %% ══════════════════════════════
    style Creational  fill:#EEEDFE,stroke:#534AB7,color:#26215C
    style Structural  fill:#E1F5EE,stroke:#0F6E56,color:#04342C
    style Behavioral  fill:#FAEEDA,stroke:#854F0B,color:#412402

    style Singleton       fill:#CECBF6,stroke:#534AB7,color:#26215C
    style Director        fill:#CECBF6,stroke:#534AB7,color:#26215C
    style Builder         fill:#CECBF6,stroke:#534AB7,color:#26215C
    style Factory         fill:#CECBF6,stroke:#534AB7,color:#26215C
    style AbstractFactory fill:#CECBF6,stroke:#534AB7,color:#26215C
    style Prototype       fill:#CECBF6,stroke:#534AB7,color:#26215C

    style Adapter   fill:#9FE1CB,stroke:#0F6E56,color:#04342C
    style Bridge    fill:#9FE1CB,stroke:#0F6E56,color:#04342C
    style Composite fill:#9FE1CB,stroke:#0F6E56,color:#04342C
    style Decorator fill:#9FE1CB,stroke:#0F6E56,color:#04342C
    style Flyweight fill:#9FE1CB,stroke:#0F6E56,color:#04342C
    style Facade    fill:#9FE1CB,stroke:#0F6E56,color:#04342C
    style Proxy     fill:#9FE1CB,stroke:#0F6E56,color:#04342C

    style Mediator     fill:#FAC775,stroke:#854F0B,color:#412402
    style Chain        fill:#FAC775,stroke:#854F0B,color:#412402
    style Command      fill:#FAC775,stroke:#854F0B,color:#412402
    style Interpreter  fill:#FAC775,stroke:#854F0B,color:#412402
    style Observer     fill:#FAC775,stroke:#854F0B,color:#412402
    style State        fill:#FAC775,stroke:#854F0B,color:#412402
    style Memento      fill:#FAC775,stroke:#854F0B,color:#412402
    style Iterator     fill:#FAC775,stroke:#854F0B,color:#412402
    style Strategy     fill:#FAC775,stroke:#854F0B,color:#412402
    style Template     fill:#FAC775,stroke:#854F0B,color:#412402
    style Visitor      fill:#FAC775,stroke:#854F0B,color:#412402
```

---

## ملخص العلاقات

| الاسم الأدبي | النمط | الكلاس | يعتمد على |
|---|---|---|---|
| المدير العام للشركة | `Singleton` | `CompanyDirectorGeneral` | يبدأ كل شيء |
| المهندس المعماري | `Director` | `ArchitectDirector` | `Builder` |
| رئيس فريق البناء | `Builder` | `ConstructionForeman` | `AbstractFactory` · `Prototype` |
| مهندس توزيع الفرق | `Factory Method` | `TeamFactory` | — |
| مهندس التوريدات المتكاملة | `Abstract Factory` | `HospitalProjectTeamFactory` | — |
| مهندس نسخ المخططات | `Prototype` | `HospitalBlueprint` | — |
| مهندس الربط والتهيئة | `Adapter` | `AccountingAdapter` | `Composite` |
| مهندس الفصل التقني | `Bridge` | `HospitalConstructionBridge` | `Decorator` · `Flyweight` |
| مهندس التكامل الهندسي | `Composite` | `HospitalComposite` | `Facade` |
| مهندس التشطيبات | `Decorator` | `FinishingDecorator` | `Facade` |
| مهندس تحسين الموارد | `Flyweight` | `MaterialFlyweight` | `Facade` |
| موظف خدمة العملاء | `Facade` | `ClientServiceFacade` | `Proxy` |
| رجل الأمن | `Proxy` | `SecurityProxy` | — |
| سياسة ربط الأقسام | `Mediator` | `DepartmentHub` | `Command` |
| مسار الصلاحيات | `Chain of Responsibility` | `ApprovalHandler` | `Interpreter` · `Observer` |
| سجل توثيق العمليات | `Command` | `ConstructionInvoker` | `State` |
| سياسة معالجة البيانات | `Interpreter` | `PermitInterpreter` | `State` |
| نظام التنبيهات المركزية | `Observer` | `ProjectNotifier` | `Memento` |
| بروتوكول حالة العمل | `State` | `ProjectStateContext` | `Iterator` · `Strategy` |
| سياسة الاستعادة والطوارئ | `Memento` | `ProjectArchive` | `Template Method` |
| سياسة الفحص الدوري | `Iterator` | `DepartmentIterator` | `Visitor` |
| سياسة اختيار المنهجية | `Strategy` | `ConstructionPlanner` | `Visitor` |
| نموذج العمل القياسي | `Template Method` | `ProjectWorkflow` | `Visitor` |
| بروتوكول التفتيش الخارجي | `Visitor` | `InspectionVisitor` | نهاية المشروع |

</div>
