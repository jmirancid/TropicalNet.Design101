using System.ComponentModel.DataAnnotations;
using Design101.Entities.Resources;
using Framework.Entities;
using Framework.Entities.Resources;

namespace Design101.Entities
{
    [MetadataType(typeof(User_Metadata))]
    public partial class User : BaseEntity
    {
        public override int Id
        {
            get
            {
                return UserId;
            }
            set
            {
                UserId = value;
            }
        }
    }

    public class User_Metadata
    {
        [Display(Name = "Entity_Role", ResourceType = typeof(Ent_UserResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public int RoleId { get; set; }

        [Display(Name = "Entity_Name", ResourceType = typeof(Ent_UserResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public string Name { get; set; }

        [Display(Name = "Entity_Phone", ResourceType = typeof(Ent_UserResource))]
        public string Phone { get; set; }

        [Display(Name = "Entity_Email", ResourceType = typeof(Ent_UserResource))]
        public string Email { get; set; }

        [Display(Name = "Entity_Login", ResourceType = typeof(Ent_UserResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public string Login { get; set; }

        [Display(Name = "Entity_Password", ResourceType = typeof(Ent_UserResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public string Password { get; set; }

        [Display(Name = "Entity_Enabled", ResourceType = typeof(Ent_UserResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public bool Enabled { get; set; }
    }
}
