using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using SyntacticDocs.Models;

namespace SyntacticDocs.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Document> Docs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class SeedData
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public SeedData(ApplicationDbContext db,UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task InitializeAsync()
        {
            await createDataAsync();
        }

        private async Task createDataAsync()
        {
            _db.Docs.Add(new Document{
                Alias = "main",
                Title = "Main",
                Content = @"# ![SyntacticDocs](/images/docs.png) SyntacticDocs
Welcome to the `SyntacticDocs`, the place where the technical documentations take a shape 

Go ahead, play around with this tool! Be sure to check out **document creation** using  predefined **templates** using the **Markdown** syntax, use **the editor toolbar**, or use shortcuts like `cmd-b` or `ctrl-b`.

## Getting Started
This guide can help you to get started with the `SyntacticDocs`

#### Create your document

Weather you want to describes handling, functionality or architecture of your product or documenting a product under development or use, the `SyntacticDocs` is just designed to help you do that.

It makes it very simple to create **technical documentations** of any type using its prebuild **markdown templates**, choosing the document templates will help you to **focus on the content** of your documents.

#### Have it everywhere

Once your document is saved, and it's **instantly available** across all your devices and even if are **offline**. Never worry about where you saved something because it's in one single location in the `SyntacticDocs`. You can start on your laptop then update your document on your tablet and review it on your phone.  All the workflow is available on **any device and any platform**.

#### Collaborate with anyone

Document **collaboration** will help your team to work together on a **single document** to achieve a single final version, `SyntacticDocs` helps you achieve that **faster, smarter** and in a **secure manner**.

#### Find anything fast

Whether it's code snippets, text, diagrams or documents, you need an **easy way to find** it and its related data. The `SyntacticDocs` helps you find **any asset** in very **fast way** due to its **optimized search engine** that has been designed to work very well for technical content.

#### Share with anyone

Having the documents and articles in single location makes it **easy to share** them in **secure way**, `SyntacticDocs` help you achieve that using its **modern sharing mechanism** that helps you shape big ideas by collaborating seamlessly with co-workers in a group document.",
                Documents = new List<Document>{
                    new Document{
                        Alias = "getting-started",
                        Title = "Getting Started",                
                        Content = @"# Getting Started
This guide can help you to get started with the `SyntacticDocs`

#### Create your document

Weather you want to describes handling, functionality or architecture of your product or documenting a product under development or use, the `SyntacticDocs` is just designed to help you do that.

It makes it very simple to create **technical documentations** of any type using its prebuild **markdown templates**, choosing the document templates will help you to **focus on the content** of your documents.

#### Have it everywhere

Once your document is saved, and it's **instantly available** across all your devices and even if are **offline**. Never worry about where you saved something because it's in one single location in the `SyntacticDocs`. You can start on your laptop then update your document on your tablet and review it on your phone.  All the workflow is available on **any device and any platform**.

#### Collaborate with anyone

Document **collaboration** will help your team to work together on a **single document** to achieve a single final version, `SyntacticDocs` helps you achieve that **faster, smarter** and in a **secure manner**.

#### Find anything fast

Whether it's code snippets, text, diagrams or documents, you need an **easy way to find** it and its related data. The `SyntacticDocs` helps you find **any asset** in very **fast way** due to its **optimized search engine** that has been designed to work very well for technical content.

#### Share with anyone

Having the documents and articles in single location makes it **easy to share** them in **secure way**, `SyntacticDocs` help you achieve that using its **modern sharing mechanism** that helps you shape big ideas by collaborating seamlessly with co-workers in a group document."
                    },                    
                    new Document{
                        Alias = "markdown-editor",
                        Title = "Markdown Editor",                
                        Content = @"# Getting started with markdown editor
Go ahead, click on the icon <i class='fa fa-pencil-square-o' style='font-size:26px;'></i> and play around with the editor! Be sure to check out **bold** and *italic* styling, or even [links](http://google.com). You can type the Markdown syntax, use the toolbar, or use shortcuts like `cmd-b` or `ctrl-b`.

## Lists
Unordered lists can be started using the toolbar or by typing `* `, `- `, or `+ `. Ordered lists can be started by typing `1. `.

#### Unordered
* Lists are a piece of cake
* They even auto continue as you type
* A double enter will end them
* Tabs and shift-tabs work too

#### Ordered
1. Numbered lists...
2. ...work too!

## What about images?
![Yes](http://i.imgur.com/sZlktY7.png)",
Documents = new List<Document>{
                    new Document{
                        Alias = "getting-started",
                        Title = "Getting Started",                
                        Content = @"# Getting Started
This guide can help you to get started with the `SyntacticDocs`

#### Create your document

Weather you want to describes handling, functionality or architecture of your product or documenting a product under development or use, the `SyntacticDocs` is just designed to help you do that.

It makes it very simple to create **technical documentations** of any type using its prebuild **markdown templates**, choosing the document templates will help you to **focus on the content** of your documents.

#### Have it everywhere

Once your document is saved, and it's **instantly available** across all your devices and even if are **offline**. Never worry about where you saved something because it's in one single location in the `SyntacticDocs`. You can start on your laptop then update your document on your tablet and review it on your phone.  All the workflow is available on **any device and any platform**.

#### Collaborate with anyone

Document **collaboration** will help your team to work together on a **single document** to achieve a single final version, `SyntacticDocs` helps you achieve that **faster, smarter** and in a **secure manner**.

#### Find anything fast

Whether it's code snippets, text, diagrams or documents, you need an **easy way to find** it and its related data. The `SyntacticDocs` helps you find **any asset** in very **fast way** due to its **optimized search engine** that has been designed to work very well for technical content.

#### Share with anyone

Having the documents and articles in single location makes it **easy to share** them in **secure way**, `SyntacticDocs` help you achieve that using its **modern sharing mechanism** that helps you shape big ideas by collaborating seamlessly with co-workers in a group document."
                    },                    
                    new Document{
                        Alias = "markdown-editor",
                        Title = "Markdown Editor",                
                        Content = @"# Getting started with markdown editor
Go ahead, click on the icon <i class='fa fa-pencil-square-o' style='font-size:26px;'></i> and play around with the editor! Be sure to check out **bold** and *italic* styling, or even [links](http://google.com). You can type the Markdown syntax, use the toolbar, or use shortcuts like `cmd-b` or `ctrl-b`.

## Lists
Unordered lists can be started using the toolbar or by typing `* `, `- `, or `+ `. Ordered lists can be started by typing `1. `.

#### Unordered
* Lists are a piece of cake
* They even auto continue as you type
* A double enter will end them
* Tabs and shift-tabs work too

#### Ordered
1. Numbered lists...
2. ...work too!

## What about images?
![Yes](http://i.imgur.com/sZlktY7.png)"}
                }
}
                }
            });

            await _db.SaveChangesAsync();
        }
    }
}
