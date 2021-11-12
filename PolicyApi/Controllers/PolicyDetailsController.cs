using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolicyApi.Models;

namespace PolicyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyDetailsController : ControllerBase   
    {
        private readonly PolicyDetailContext _context;

        public PolicyDetailsController(PolicyDetailContext context)
        {
            _context = context;
        }

        // GET: api/PolicyDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyDetail>>> GetPolicyDetails()
        {
            return await _context.PolicyDetails.ToListAsync();
        }

        [HttpGet]
        [Route("PolicyByCustomerID/{id}")]
        public async Task<ActionResult<IEnumerable<PolicyDetail>>> GetPolicyDetailsByCustomerId(int id)
        {
            var policyDetail =  await _context.PolicyDetails.Where(a=> a.Customer_Id == id).ToListAsync() ;

            if (policyDetail == null)
            {
                return NotFound();
            }
            return policyDetail;
        }

        [HttpGet]
        [Route("PolicyByRegion/{region}")]
        public async Task<ActionResult<IEnumerable<PolicyDetail>>> GetPolicyDetailsByRegion(string region)
        {
            var policyDetail = await _context.PolicyDetails.Where(a => a.CustomerRegion == region).ToListAsync();

            if (policyDetail == null)
            {
                return NotFound();
            }
            return policyDetail;
        }


        // GET: api/PolicyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyDetail>> GetPolicyDetail(int id)
        {
            var policyDetail = await _context.PolicyDetails.FindAsync(id);

            if (policyDetail == null)
            {
                return NotFound();
            }

            return policyDetail;
        }

        // PUT: api/PolicyDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyDetail(int id, PolicyDetail policyDetail)
        {
            //var pd = await _context.PolicyDetails.FindAsync(id);
            //policyDetail.DateOfPurchase = pd.DateOfPurchase;

            if (id != policyDetail.Policy_Id)
            {
                return BadRequest();
            }

            _context.Entry(policyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PolicyDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyDetail>> PostPolicyDetail(PolicyDetail policyDetail)
        {
            _context.PolicyDetails.Add(policyDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicyDetail", new { id = policyDetail.Policy_Id }, policyDetail);
        }

        // DELETE: api/PolicyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicyDetail(int id)
        {
            var policyDetail = await _context.PolicyDetails.FindAsync(id);
            if (policyDetail == null)
            {
                return NotFound();
            }

            _context.PolicyDetails.Remove(policyDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PolicyDetailExists(int id)
        {
            return _context.PolicyDetails.Any(e => e.Policy_Id == id);
        }

       
    }
}
