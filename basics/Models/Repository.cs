namespace basics.Models{

    public class Repository{

        private static readonly List<Bootcamp> _bootcamps = new();

        static Repository(){
            _bootcamps = new List<Bootcamp>(){
            new Bootcamp() {Id = 1, Title = "aspnet Bootcamp", Description = "3 haftalık eğitim", Image = "1.png"},
            new Bootcamp() {Id = 2, Title = "unity Bootcamp", Description = "3 haftalık eğitim", Image = "2.png"},
            new Bootcamp() {Id = 3, Title = "React Bootcamp", Description = "3 haftalık eğitim", Image = "3.png"},
            };
        }

        public static List<Bootcamp> Bootcamps{get{return _bootcamps;}}

        public static Bootcamp? GetById(int? id){
            return _bootcamps.FirstOrDefault(c=>c.Id == id);
        }
    }
}