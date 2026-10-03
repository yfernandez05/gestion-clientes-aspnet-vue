namespace apiservicesv1.Utils
{
    public class RuleManager
    {
        public const string FIELD_NAME_STATE = "estado";
        public const char ACTIVE_STATE = 'A';
        public const char DISABLED_STATE = 'E';
        public const string ACTIVE_STATE_NAME = "Activo";
        public const string DISABLED_STATE_NAME = "Eliminado";

        public static string GetStateName(char state)
        {
            return state == ACTIVE_STATE ? ACTIVE_STATE_NAME : DISABLED_STATE_NAME;
        }

        public static bool GetIsActive(char state)
        {
            return state == ACTIVE_STATE;
        }
    }
}
