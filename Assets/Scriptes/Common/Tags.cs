namespace Assets.Scriptes {
    public static class Tags {

        public static readonly string PLATE = "Plate";
        public static readonly string PLATE_ACCEPTOR = "PlateAcceptor";
        public static readonly string FLOOR = "Floor";
        public static readonly string SANDWICH = "Sandwich";

        public static bool IfPlateOrFloor(string tag) {
            return tag == PLATE || tag == FLOOR;
        }
        public static bool IfPlate(string tag) {
            return tag == PLATE;
        }
        public static bool IfFloor(string tag) {
            return tag == FLOOR;
        }
    }
}