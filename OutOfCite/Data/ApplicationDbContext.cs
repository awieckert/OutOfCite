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
                },
                new Article ()
                {
                    Id = 5,
                    AuthorId = 5,
                    AffiliationId = 2,
                    Title = "Crizotinib-induced abnormal signal processing in the retina",
                    Abstract = "Molecular target therapy for cancer is characterized by unique adverse effects that are not usually observed with cytotoxic chemotherapy. For example, the anaplastic lymphoma kinase (ALK)-tyrosine kinase inhibitor crizotinib causes characteristic visual disturbances, whereas such effects are rare when another ALK-tyrosine kinase inhibitor, alectinib, is used. To elucidate the mechanism responsible for these visual disturbances, the responses to light exhibited by retinal ganglion cells treated with these agents were evaluated using a C57BL6 mouse ex vivo model. Both crizotinib and alectinib changed the firing rate of ON and OFF type retinal ganglion cells. However, the ratio of alectinib-affected cells (15.7%) was significantly lower than that of crizotinib-affected cells (38.6%). Furthermore, these drugs changed the response properties to light stimuli of retinal ganglion cells in some of the affected cells, i.e., OFF cells responded to both ON and OFF stimuli, etc. Finally, the expressions of ALK (a target receptor of both crizotinib and alectinib) and of MET and ROS1 (additional target receptors of crizotinib) were observed at the mRNA level in the retina. Our findings suggest that these drugs might target retinal ganglion cells and that the potency of the drug actions on the light responses of retinal ganglion cells might be responsible for the difference in the frequencies of visual disturbances observed between patients treated with crizotinib and those treated with alectinib. The present experimental system might be useful for screening new molecular target agents prior to their use in clinical trials.",
                    URL = "https://journals.plos.org/plosone/article?id=10.1371/journal.pone.0135521",
                    Journal = "PLoS One",
                    JournalImpact = 2.7,
                    Citations = 3
                },
                new Article ()
                {
                    Id = 6,
                    AuthorId = 6,
                    AffiliationId = 2,
                    Title = "In vitro evolution and affinity-maturation with Coliphage Qβ display",
                    Abstract = "The Escherichia coli bacteriophage, Qβ (Coliphage Qβ), offers a favorable alternative to M13 for in vitro evolution of displayed peptides and proteins due to high mutagenesis rates in Qβ RNA replication that better simulate the affinity maturation processes of the immune response. We describe a benchtop in vitro evolution system using Qβ display of the VP1 G-H loop peptide of foot-and-mouth disease virus (FMDV). DNA encoding the G-H loop was fused to the A1 minor coat protein of Qβ resulting in a replication-competent hybrid phage that efficiently displayed the FMDV peptide. The surface-localized FMDV VP1 G-H loop cross-reacted with the anti-FMDV monoclonal antibody (mAb) SD6 and was found to decorate the corners of the Qβ icosahedral shell by electron microscopy. Evolution of Qβ-displayed peptides, starting from fully degenerate coding sequences corresponding to the immunodominant region of VP1, allowed rapid in vitro affinity maturation to SD6 mAb. Qβ selected under evolutionary pressure revealed a non-canonical, but essential epitope for mAb SD6 recognition consisting of an Arg-Gly tandem pair. Finally, the selected hybrid phages induced polyclonal antibodies in guinea pigs with good affinity to both FMDV and hybrid Qβ-G-H loop, validating the requirement of the tandem pair epitope. Qβ-display emerges as a novel framework for rapid in vitro evolution with affinity-maturation to molecular targets.",
                    URL = "https://journals.plos.org/plosone/article?id=10.1371/journal.pone.0113069",
                    Journal = "PLoS One",
                    JournalImpact = 2.7,
                    Citations = 2
                },
                new Article ()
                {
                    Id = 7,
                    AuthorId = 7,
                    AffiliationId = 2,
                    Title = "High-Throughput RNA Interference Screening: Tricks of the Trade",
                    Abstract = "The process of validating an assay for high-throughput screening (HTS) involves identifying sources of variability and developing procedures that minimize the variability at each step in the protocol. The goal is to produce a robust and reproducible assay with good metrics. In all good cell-based assays, this means coefficient of variation (CV) values of less than 10% and a signal window of fivefold or greater. HTS assays are usually evaluated using Z′ factor, which incorporates both standard deviation and signal window. A Z′ factor value of 0.5 or higher is acceptable for HTS. We used a standard HTS validation procedure in developing small interfering RNA (siRNA) screening technology at the HTS center at Southern Research. Initially, our assay performance was similar to published screens, with CV values greater than 10% and Z′ factor values of 0.51 ± 0.16 (average ± standard deviation). After optimizing the siRNA assay, we got CV values averaging 7.2% and a robust Z′ factor value of 0.78 ± 0.06 (average ± standard deviation). We present an overview of the problems encountered in developing this whole-genome siRNA screening program at Southern Research and how equipment optimization led to improved data quality.",
                    URL = "http://journals.sagepub.com/doi/abs/10.1177/2211068213486786",
                    Journal = "	Journal of Laboratory Automation",
                    JournalImpact = 2.6,
                    Citations = 4
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
                },
                new Author()
                {
                    Id = 5,
                    FirstName = "Steven",
                    LastName = "Barnes",
                    HIndex = 30
                },
                new Author()
                {
                    Id = 6,
                    FirstName = "Steven",
                    LastName = "Aller",
                    HIndex = 29
                },
                new Author()
                {
                    Id = 7,
                    FirstName = "Mary Ann",
                    LastName = "Bjornsti",
                    HIndex = 30
                },
                new Author()
                {
                    Id = 8,
                    FirstName = "",
                    LastName = "",
                    HIndex = 3
                }
                );
        }
    }
}
