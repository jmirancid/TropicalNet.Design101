﻿using System.ComponentModel.DataAnnotations;
using Design101.Entities.Resources;
using Framework.Entities;
using Framework.Entities.Resources;

namespace Design101.Entities
{
    [MetadataType(typeof(Role_Metadata))]
    public partial class Role : BaseEntity
    {
        public override int Id
        {
            get
            {
                return RoleId;
            }
            set
            {
                RoleId = value;
            }
        }
    }

    public class Role_Metadata
    {
        [Display(Name = "Entity_Name", ResourceType = typeof(Ent_RoleResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public string Name { get; set; }

        [Display(Name = "Entity_Description", ResourceType = typeof(Ent_RoleResource))]
        public string Description { get; set; }
    }
}
