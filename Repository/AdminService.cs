using FastX_CaseStudy.Models;
using System.Security.Cryptography;

namespace FastX_CaseStudy.Repository
{
    public class AdminService : IAdmin
    {
        private readonly BusBookingContext _context;

        public AdminService(BusBookingContext context)
        {
            _context = context;
        }
        public int AddOperator(BusOperator op)
        {
            try
            {
                if (op != null)
                {
                    _context.BusOperators.Add(op);
                    _context.SaveChanges();
                    return op.OperatorId;
                }
                return 0;
            }
            catch (Exception ex) {
                throw new Exception($"Error adding bus operator: {ex.Message}");
            }
        }

        public int AddUser(User userData)
        {
            try
            {
                if (userData != null)
                {
                    _context.Users.Add(userData);
                    _context.SaveChanges();
                    return userData.UserId;
                }
                return 0;
            }
            catch (Exception ex) {
                throw new Exception($"Error adding user: {ex.Message}");
            }
            }

        public string DeleteOperator(int opid)
        {
           var operator1=_context.BusOperators.FirstOrDefault(op=> op.OperatorId == opid);
            if (operator1 != null) { 
            _context.BusOperators.Remove(operator1);
                _context.SaveChanges();
                return $"Bus Operator with id {operator1.OperatorId} deleted successfully";
            }
            else
            {
                return "Bus Operator not found.";
            }
        }

        public string DeleteUser(int userId)
        {
            var user1 = _context.Users.FirstOrDefault(op => op.UserId == userId);
            if (user1 != null)
            {
                _context.Users.Remove(user1);
                _context.SaveChanges();
                return $"User with id {user1.UserId} deleted successfully";
            }
            else
            {
                return "User not found.";
            }
        }

        public List<BusOperator> GetAllOperators()
        {
          var operator1= _context.BusOperators.ToList();
            if (operator1.Count>0)
                return operator1;

            else
                return null;
        }

        public List<User> GetAllUsers()
        {
          var users= _context.Users.ToList();
            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                return null;
            }
        }

        public BusOperator GetOperatorDetails(int opid)
        {
        if(opid!=0 || opid != null)
            {
               var operator1=_context.BusOperators.FirstOrDefault(x => x.OperatorId == opid);
                if (operator1 != null)
                    return operator1;

                else
                    return null;
            }
            return null;
        }

        public User GetUserDetails(int userid)
        {
            if (userid != 0 || userid!= null)
            {
                var operator1 = _context.Users.FirstOrDefault(x => x.UserId == userid);
                if (operator1 != null)
                    return operator1;

                else
                    return null;
            }
            return null;
        }

        public string UpdateOperator(int opid, BusOperator op)
        {
            var existingoperator= _context.BusOperators.FirstOrDefault(x=>x.OperatorId == opid);
            if(existingoperator != null)
            {
                existingoperator.OperatorId = op.OperatorId;
                existingoperator.OperatorName = op.OperatorName;
                existingoperator.OperatorPhone = op.OperatorPhone;
                existingoperator.DateCreated = op.DateCreated;
                existingoperator.BusId = op.BusId;
                _context.Entry(existingoperator).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Something went wrong";
            }
        }

        public string UpdateUser(int userid, User userdata)
        {
            var existinguser= _context.Users.FirstOrDefault(x=>x.UserId == userid);
            if (existinguser != null) {
                existinguser.UserId = userdata.UserId;
                existinguser.UserName = userdata.UserName;
                existinguser.Email = userdata.Email;
                existinguser.DateCreated = userdata.DateCreated;
                existinguser.Address = userdata.Address;
                existinguser.Role = userdata.Role;
                existinguser.PhoneNumber = userdata.PhoneNumber;
                existinguser.Gender = userdata.Gender;
                _context.Entry(existinguser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return "Record updated successfully";
            }
            return "Something went wrong";
        }
    }
}
