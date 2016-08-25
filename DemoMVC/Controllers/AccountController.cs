
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class AccountController : Controller
    {
        private DAL.AccountContext db = new DAL.AccountContext();
        // GET: Account
        public ActionResult Index()
        {
            return View(db.SysUsers);
        }
        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前。。。";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            //获取表单数据
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];
            //进行下一步处理，这里先改下文字
            var user = db.SysUsers.Where(b => b.Email == email && b.Password == password);
            if (user .Count ()>0)
            { ViewBag.LoginState = email + "登录后。。。"; }
            else
            { ViewBag.LoginState = email + "用户不存在。。。"; }
            
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Register = "注册前。。。";
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection fc)
        {
            //获取表单数据
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];
            //进行下一步处理，这里先改下文字
            ViewBag.LoginState = "注册账号" + email;
            return View();
        }
        
    }
    //public class AccountContext : DbContext
    //{
    //    public AccountContext()
    //        : base("AccountContext")
    //    {
    //    }
    //    public DbSet<SysUser> SysUsers { get; set; }
    //    public DbSet<SysRole> SysRoles { get; set; }
    //    public DbSet<SysUserRole> SysUserRoles { get; set; }
    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    //    }
    //}
}