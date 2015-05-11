using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Design101.Entities.Resources;
using Framework.Entities;
using Framework.Entities.Resources;

namespace Design101.Entities
{
    [MetadataType(typeof(Document_Metadata))]
    public partial class Document : BaseEntity
    {
        public override int Id
        {
            get
            {
                return DocumentId;
            }
            set
            {
                DocumentId = value;
            }
        }

        public Document()
        {
            this.Assigned = DateTime.Now;
        }
    }

    public class Document_Metadata
    {
        [Display(Name = "Entity_User", ResourceType = typeof(Ent_DocumentResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public int UserId { get; set; }

        [Display(Name = "Entity_Name", ResourceType = typeof(Ent_DocumentResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public string Name { get; set; }

        [Display(Name = "Entity_Description", ResourceType = typeof(Ent_DocumentResource))]
        public string Description { get; set; }

        [Display(Name = "Entity_Path", ResourceType = typeof(Ent_DocumentResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public string Path { get; set; }

        [Display(Name = "Entity_Enabled", ResourceType = typeof(Ent_DocumentResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public bool Enabled { get; set; }

        [Display(Name = "Entity_Priority", ResourceType = typeof(Ent_DocumentResource))]
        public int Priority { get; set; }

        [Display(Name = "Entity_Assigned", ResourceType = typeof(Ent_DocumentResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public System.DateTime Assigned { get; set; }
    }
}
