using System.ComponentModel.DataAnnotations;

namespace PokemonForum
{
    public class Publication
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string NickName { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(512)]
        public string Story { get; set; }

    }
}