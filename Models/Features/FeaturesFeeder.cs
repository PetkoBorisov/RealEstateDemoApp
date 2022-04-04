namespace RealEstateDemoApp.Models.Features
{
    public static class FeaturesFeeder
    {
        public static List<FeatureModel> feedIndoorFeatures()
        {
            return new List<FeatureModel> {
                new FeatureModel(){ Value = "Ensuite"},
                new FeatureModel(){ Value = "Dishwasher"},
                new FeatureModel(){ Value = "Study"},
                new FeatureModel(){ Value = "Built in robes"},
                new FeatureModel(){ Value = "Alarm system"},
                new FeatureModel(){ Value = "Broadband"},
                 new FeatureModel(){ Value = "Gym"},
                  new FeatureModel(){ Value = "Workshop"}
            };
        }

        public static List<FeatureModel> feedOutdoorFeatures()
        {
            return new List<FeatureModel> {
                new FeatureModel(){ Value = "Balcony"},
                new FeatureModel(){ Value = "Outdoor Area"},
                new FeatureModel(){ Value = "Undercover parking"},
                new FeatureModel(){ Value = "Shed"},
                new FeatureModel(){ Value = "Fully fenced"},
                new FeatureModel(){ Value = "Tennis court"}
            };
        }


        public static List<FeatureModel> feedClimateFeatures()
        {
            return new List<FeatureModel> {
                new FeatureModel(){ Value = "Air conditioning"},
                new FeatureModel(){ Value = "Solar panels"},
                new FeatureModel(){ Value = "Heating"},
                new FeatureModel(){ Value = "High energy efficiency"},
                new FeatureModel(){ Value = "Watertank"},
                new FeatureModel(){ Value = "Solar hot water"}
            };
        }

    }
}
