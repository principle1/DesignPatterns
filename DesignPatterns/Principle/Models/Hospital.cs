namespace Principle.Models {

    // المستشفى
    public class Hospital {
        public string Name { get; set; }
        public string Location { get; set; }
        public int FloorsCount { get; set; }
        public bool FoundationCompleted { get; set; }
        public bool WallsCompleted { get; set; }
        public bool RoofCompleted { get; set; }
        public bool OperatingRoomsCompleted { get; set; }
        public bool EmergencyDepartmentCompleted { get; set; }
        public override string ToString() {
            return $"""
                    Hospital Name         : {Name}
                    Location              : {Location}
                    Floors                : {FloorsCount}
                    Foundation            : {FoundationCompleted}
                    Walls                 : {WallsCompleted}
                    Roof                  : {RoofCompleted}
                    Operating Rooms       : {OperatingRoomsCompleted}
                    Emergency Department  : {EmergencyDepartmentCompleted}
                    """;
        }
    }

}
