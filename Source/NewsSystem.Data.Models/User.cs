using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<Article> articles;

        public User()
        {
            this.articles = new HashSet<Article>();
        }

        [Key]
        public override string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public override string UserName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string LastName { get; set; }

        //public virtual Guid ArticleId { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
