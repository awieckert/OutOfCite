using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutOfCite.Models;

namespace OutOfCite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Affiliation> Affiliations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<FavoriteArticle> FavoriteArticles { get; set; }
        public DbSet<SubmittedArticle> SubmittedArticles { get; set; }
        public DbSet<UserAffiliation> UserAffiliations { get; set; }
        public DbSet<UserArticleVote> UserArticleVotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
            .HasMany(a => a.UserArticleVotes)
            .WithOne(u => u.ApplicationUser)
            .OnDelete(DeleteBehavior.Restrict);

            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Admin",
                LastName = "Istrator",
                UserName = "Admin2",
                NormalizedUserName = "ADMIN2",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                LinkedIn = "www.linkedin.com/in/admin2",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            ApplicationUser user2 = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Adam",
                LastName = "Wieckert",
                UserName = "TerriBrogen",
                NormalizedUserName = "TERRIBROGEN",
                Email = "wiec1369@gmail.com",
                NormalizedEmail = "WIEC1369@GMAIL.COM",
                LinkedIn = "www.linkedin.com/in/awieckert",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash2.HashPassword(user2, "Password123!");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);


            modelBuilder.Entity<Affiliation>().HasData(
                new Affiliation()
                {
                    Id = 1,
                    Name = "Neuroscience"
                },
                new Affiliation()
                {
                    Id = 2,
                    Name = "Toxicology"
                },
                new Affiliation()
                {
                    Id = 3,
                    Name = "Developmental Biology"
                },
                new Affiliation()
                {
                    Id = 4,
                    Name = "Cancer"
                }
            );

            modelBuilder.Entity<Article>().HasData(
                new Article()
                {
                    Id = 1,
                    AuthorId = 2,
                    AffiliationId = 1,
                    Title = "Development of glutamatergic innervation during maturation of adult-born neurons",
                    Abstract = "The dentate gyrus is the entrance of the hippocampal formation and a primary target of excitatory afferents from the entorhinal cortex that carry spatial and sensory information. Mounting evidence suggests that continual adult neurogenesis contributes to appropriate processing of cortical information. The ongoing integration of adult born neurons dynamically modulates connectivity of the network, potentially contributing to dentate cognitive function. Here we review the current understanding of how glutamatergic innervation develops during the progression of adult-born neuron maturation. Summarizing the developmental stages of dentate neurogenesis, we also demonstrate that new neurons at an immature stage of maturation begin to process afferent activity from both medial and lateral entorhinal cortices.",
                    URL = "https://link.springer.com/article/10.1007/s11515-015-1362-2",
                    Journal = "Frontiers in Biology",
                    JournalImpact = 1.03,
                    Citations = 0
                },
                new Article()
                {
                    Id = 2,
                    AuthorId = 1,
                    AffiliationId = 1,
                    Title = "Thinking about brain and consciousness",
                    Abstract = "In this brief article I present as a preamble to a developing theory a summary of ideas and evidence discussed elsewhere (see Damasio and Meyer (2008) In: Laureys S, Tononi G (eds) The neurology of consciousness. Elsevier, pp 3–14; Damasio (2010) Self comes to mind. Pantheon). They pertain to the nature of consciousness, to the position and role of consciousness in evolutionary history, and to how the brain constructs consciousness at the level of large-scale systems.",
                    URL = "https://link.springer.com/chapter/10.1007/978-3-642-18015-6_3",
                    Journal = "Research and Perspectives in Neurosciences",
                    JournalImpact = 3.50,
                    Citations = 1

                },
                new Article ()
                {
                    Id = 3,
                    AuthorId = 3,
                    AffiliationId = 1,
                    Title = "Spillover-Mediated Feedforward Inhibition Functionally Segregates Interneuron Activity",
                    Abstract = "Neurotransmitter spillover represents a form of neural transmission not restricted to morphologically defined synaptic connections. Communication between climbing fibers (CFs) and molecular layer interneurons (MLIs) in the cerebellum is mediated exclusively by glutamate spillover. Here, we show how CF stimulation functionally segregates MLIs based on their location relative to glutamate release. Excitation of MLIs that reside within the domain of spillover diffusion coordinates inhibition of MLIs outside the diffusion limit. CF excitation of MLIs is dependent on extrasynaptic NMDA receptors that enhance the spatial and temporal spread of CF signaling. Activity mediated by functionally segregated MLIs converges onto neighboring Purkinje cells (PCs) to generate a long-lasting biphasic change in inhibition. These data demonstrate how glutamate release from single CFs modulates excitability of neighboring PCs, thus expanding the influence of CFs on cerebellar cortical activity in a manner not predicted by anatomical connectivity.",
                    URL = "https://www.sciencedirect.com/science/article/pii/S0896627313003218",
                    Journal = "Neuron",
                    JournalImpact = 14.3,
                    Citations = 24
                },
                new Article ()
                {
                    Id = 4,
                    AuthorId = 4,
                    AffiliationId = 1,
                    Title = "Targeting of the class II transactivator attenuates inflammation and neurodegeneration in an alpha-synuclein model of Parkinson's disease ",
                    Abstract = "Parkinson’s disease (PD) is characterized by intracellular alpha-synuclein (α-syn) inclusions, progressive death of dopaminergic neurons in the substantia nigra pars compacta (SNpc), and activation of the innate and adaptive immune systems. Disruption of immune signaling between the central nervous system (CNS) and periphery, such as through targeting the chemokine receptor type 2 (CCR2) or the major histocompatibility complex II (MHCII), is neuroprotective in rodent models of PD, suggesting a key role for innate and adaptive immunity in disease progression. The purpose of this study was to investigate whether genetic knockout or RNA silencing of the class II transactivator (CIITA), a transcriptional co-activator required for MHCII induction, is effective in reducing the neuroinflammation and neurodegeneration observed in an α-syn mouse model of PD.",
                    URL = "https://jneuroinflammation.biomedcentral.com/articles/10.1186/s12974-018-1286-2",
                    Journal = "Journal of Neuroinflammation",
                    JournalImpact = 4,
                    Citations = 1
                }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = 1,
                    FirstName = "Antonio",
                    LastName = "Damasio",
                    HIndex = 97
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Linda",
                    LastName = "Wadiche",
                    HIndex = 26
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "Jacques",
                    LastName = "Wadiche",
                    HIndex = 17
                },
                new Author ()
                {
                    Id = 4,
                    FirstName = "David",
                    LastName = "Standard",
                    HIndex = 66
                }
                );
        }
    }
}
