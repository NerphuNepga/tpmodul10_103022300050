using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using tpmodul10_103022300050;

namespace tpmodul10_103022300050.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static readonly List<Mahasiswa> mahasiswa = new ()
        {
            new Mahasiswa ( "Muhammad Arrayan Fikri", "103022300050" ),
            new Mahasiswa ( "Adrian Putra Perkasa", "103022300041" ),
            new Mahasiswa ( "Yappier Albertus Febriandi Krisna Putra", "103022300148" ),
            new Mahasiswa ( "Achmad Maulana Arief", "103022330157" ),
        };
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
        {
            return Ok(mahasiswa);
        }

        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }

            return Ok(mahasiswa[id]);
        }

        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mhsBaru)
        {
            if (string.IsNullOrWhiteSpace(mhsBaru.Nama) || string.IsNullOrWhiteSpace(mhsBaru.Nim))
            {
                return BadRequest(new { message = "Nama dan NIM harus diisi" });
            }

            mahasiswa.Add(mhsBaru);
            return Ok(new { message = "Mahasiswa telah ditambahkan", id = mahasiswa.Count -1});
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMahasiswa(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }
            mahasiswa.RemoveAt(id);
            return Ok(new { message = "Mahasiswa berhasil dihapus" });
        }
    }
}
