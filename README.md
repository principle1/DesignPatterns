[README.md](https://github.com/user-attachments/files/29575071/README.md)
<div dir="rtl">

# Design Patterns — Principle Construction

> مخطط يوضح تسلسل الـ 23 نمط وعلاقاتهم ببعض عبر مراحل المشروع الثلاث.

```mermaid
flowchart TD

    Client([Client])

    %% ══════════════════════════════
    %%  مرحلة التأسيس — Creational
    %% ══════════════════════════════
    subgraph Creational["🏗 مرحلة التأسيس — Creational"]
        direction TB
        Singleton["CompanyDirectorGeneral\nSingleton"]
        Director["ArchitectDirector\nDirector"]
        Builder["ConstructionForeman\nBuilder"]
        Factory["TeamFactory\nFactory Method"]
        AbstractFactory["HospitalProjectTeamFactory\nAbstract Factory"]
        Prototype["HospitalBlueprint\nPrototype"]

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
        Adapter["AccountingAdapter\nAdapter"]
        Bridge["HospitalConstructionBridge\nBridge"]
        Composite["HospitalComposite\nComposite"]
        Decorator["FinishingDecorator\nDecorator"]
        Flyweight["MaterialFlyweight\nFlyweight"]
        Facade["ClientServiceFacade\nFacade"]
        Proxy["SecurityProxy\nProxy"]

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
        Mediator["DepartmentHub\nMediator"]
        Chain["ApprovalHandler\nChain of Responsibility"]
        Command["ConstructionInvoker\nCommand"]
        Interpreter["PermitInterpreter\nInterpreter"]
        Observer["ProjectNotifier\nObserver"]
        State["ProjectStateContext\nState"]
        Memento["ProjectArchive\nMemento"]
        Iterator["DepartmentIterator\nIterator"]
        Strategy["ConstructionPlanner\nStrategy"]
        Template["ProjectWorkflow\nTemplate Method"]
        Visitor["InspectionVisitor\nVisitor"]

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

| النمط | يُستخدم مع / يعتمد على |
|---|---|
| `Singleton` | يبدأ كل شيء — يستدعي `Director` و `Builder` |
| `Director` | يُوجّه `Builder` خطوة بخطوة |
| `Builder` | يطلب من `Factory Method` و `Abstract Factory` و `Prototype` |
| `Adapter` | يُمرر النتيجة لـ `Composite` |
| `Bridge` | يُغذّي `Decorator` و `Flyweight` |
| `Facade` | يجمع `Composite` + `Decorator` + `Flyweight` في واجهة واحدة |
| `Proxy` | يحرس مدخل `Facade` |
| `Mediator` | يُنسّق قبل `Command` |
| `Chain` | يُقرر بعدها `Interpreter` و `Observer` |
| `Observer` | يُخطر ثم يُحفّز `Memento` |
| `State` | يفتح الطريق لـ `Iterator` و `Strategy` |
| `Visitor` | نهاية المشروع — يتلقى من `Iterator` و `Strategy` و `Template` |

</div>
