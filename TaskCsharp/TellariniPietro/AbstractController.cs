using BrickBreaker.Controllers.Listener;
using BrickBreaker.Models;
using BrickBreaker.Models.Controller;
using BrickBreaker.Models.GameObjects;
using BrickBreaker.Models.Levels;
using BrickBreaker.Models.Ranks;

namespace BrickBreaker.Controllers
{
    public abstract class AbstractController : AnimationTimer
    {
        private UserController userController;
        private ErrorListener errorListener;
        private InputController inputController;
        private LevelController levelController;
        private RankController rankController;

        public AbstractController()
        {
            userController = new UserController();
            errorListener = new ErrorListener();
            inputController = new InputController();
            levelController = new LevelController();
            rankController = new RankController();
        }

        public UserController UserController => userController;

        public InputController InputController => inputController;

        public ErrorListener ErrorListener => errorListener;

        public LevelController LevelController => levelController;

        public RankController RankController => rankController;
    }
}
