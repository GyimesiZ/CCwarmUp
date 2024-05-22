using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemilabDevOps.Models
{
    public class Lists
    {
        public readonly List<Threads> Threads = new List<Threads>
        {
            new Threads {Id = 1, Name = "Build Pipeline", Root = Case.Both},
            new Threads {Id = 2, Name = "Release Pipeline", Root = Case.Both}, 
            new Threads {Id = 3, Name = "VSTS adminisztráció", Root = Case.Both}, 
            new Threads {Id = 4, Name = "VSTS jogosultságok", Root = Case.Both}, 
            new Threads {Id = 5, Name = "GIT Repo és Branch", Root = Case.Both}, 
            new Threads {Id = 6, Name = "Installer", Root = Case.Both}, 
            new Threads {Id = 7, Name = "Testautomation", Root = Case.Both} 
        };

        public readonly List<Categories> Categories = new List<Categories>
        {
            new Categories {Name = "Új build pipeline létrehozása", Thread = 1},
            new Categories {Name = "Build pipeline elbukott", Thread = 1, Bug = true},
            new Categories {Name = "Build pipeline hibásan futott le", Thread = 1, Bug = true},
            new Categories {Name = "Build pipeline változtatása", Thread = 1},
            new Categories {Name = "Új Release pipeline létrehozása", Thread = 2},
            new Categories {Name = "Új HotFix pipeline létrehozása", Thread = 2},
            new Categories {Name = "Release pipeline megváltoztatása", Thread = 2},
            new Categories {Name = "Release pipeline elbukott", Thread = 2, Bug = true},
            new Categories {Name = "Release pipeline hibásan futott le", Thread = 2, Bug = true},
            new Categories {Name = "Új VSTS felhasználó létrehozása", Thread = 4},
            new Categories {Name = "VSTS jogosultság beállítása", Thread = 4},
            new Categories {Name = "GIT repository létrehozása", Thread = 5},
            new Categories {Name = "GIT repository átnevezése", Thread = 5},
            new Categories {Name = "GIT repository törlése", Thread = 5},
            new Categories {Name = "Branch létrehozása", Thread = 5},
            new Categories {Name = "Branch átnevezése", Thread = 5},
            new Categories {Name = "Branch archiválása", Thread = 5},
            new Categories {Name = "Branch törlése", Thread = 5},
            new Categories {Name = "Branch policy beállítása", Thread = 5},
            new Categories {Name = "Új installer ", Thread = 6},
            new Categories {Name = "Installer módosítása", Thread = 6},
        };

}
}