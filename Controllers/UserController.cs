using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.DbContexts;
using WebApiApp.Model;
using WebApiApp.Model.DbSet;

namespace WebApiApp.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public Res res = new Res();

        public UserController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpPost]
        [Route("api/User/AddUser")]
        public ActionResult<Res> AddUser(UserInfo userInfo)
        {
            try
            {

                _appDbContext.userInfo.Add(new UserInfo
                {
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    IsDelete = false,
                });

                if (_appDbContext.SaveChanges() == 1)
                {
                    res.status = true;
                    res.message = ActionStatus.Success;
                    res.data = null;
                    return StatusCode((int)StatusCodes.Status200OK, res);
                }
                else
                {
                    res.status = false;
                    res.message = ActionStatus.Fail;
                    res.data = null;
                    return StatusCode((int)StatusCodes.Status200OK, res);
                }

            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = ex.Message;
                res.data = null;
                return StatusCode((int)StatusCodes.Status500InternalServerError, res);
            }
        }

        [HttpGet]
        [Route("api/User/GetUser")]
        public ActionResult<Res> GetUser()
        {
            try
            {
                List<UserInfo> userInfos = _appDbContext.userInfo.ToList();

                res.status = true;
                res.data = userInfos;
                res.message = ActionStatus.Success;
                return StatusCode((int)StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = ex.Message;
                return StatusCode((int)StatusCodes.Status500InternalServerError, res);
            }
        }

        [HttpPost]
        [Route("api/User/UpdateUser")]
        public ActionResult<Res> DeleteUser(UserInfo userInfo)
        {
            try
            {

                UserInfo userInfo1 = _appDbContext.userInfo
                       .Where(m => m.UserId == userInfo.UserId).FirstOrDefault();

                if (userInfo1 != null)
                {
                    userInfo1.FirstName = userInfo.FirstName;
                    userInfo1.LastName = userInfo.LastName;

                    _appDbContext.userInfo.Update(userInfo1);

                    if (_appDbContext.SaveChanges() == 1)
                    {
                        res.status = true;
                        res.message = ActionStatus.Success;
                        res.data = null;
                        return StatusCode((int)StatusCodes.Status200OK, res);
                    }
                    else
                    {
                        res.status = false;
                        res.message = ActionStatus.Fail;
                        res.data = null;
                        return StatusCode((int)StatusCodes.Status200OK, res);
                    }
                }
                else
                {

                    res.status = false;
                    res.message = ActionStatus.Fail;
                    res.data = null;
                    return StatusCode((int)StatusCodes.Status200OK, res);
                }

            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = ex.Message;
                res.data = null;
                return StatusCode((int)StatusCodes.Status500InternalServerError, res);
            }
        }

        [HttpPost]
        [Route("api/User/DeleteUser/{UserId}")]
        public ActionResult<Res> DeleteUser(long UserId)
        {
            try
            {
                UserInfo userInfo1 = _appDbContext.userInfo
                       .Where(m => m.UserId == UserId).FirstOrDefault();

                if (userInfo1 != null)
                {
                    _appDbContext.userInfo.Remove(userInfo1);

                    if (_appDbContext.SaveChanges() == 1)
                    {
                        res.status = true;
                        res.message = ActionStatus.Success;
                        res.data = null;
                        return StatusCode((int)StatusCodes.Status200OK, res);
                    }
                    else
                    {
                        res.status = false;
                        res.message = ActionStatus.Fail;
                        res.data = null;
                        return StatusCode((int)StatusCodes.Status200OK, res);
                    }
                }
                else
                {
                    res.status = false;
                    res.message = ActionStatus.Fail;
                    res.data = null;
                    return StatusCode((int)StatusCodes.Status200OK, res);
                }

            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = ex.Message;
                res.data = null;
                return StatusCode((int)StatusCodes.Status500InternalServerError, res);
            }
        }
    }
}
