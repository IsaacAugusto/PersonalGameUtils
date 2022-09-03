using UnityEngine;

namespace InterfaceManager {
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIScreen : MonoBehaviour
    {
        public static UIScreen activeScreen;
        
        [HideInInspector] public UIScreen previousScreen = null;
        
        public bool isModal = false;
    
        CanvasGroup _group = null;
        
        public CanvasGroup Group
        {
            get
            {
                if (_group) return _group;
                return _group = GetComponent<CanvasGroup>();
            }
        }
        
        public static void Focus(UIScreen screen) {
            if ( activeScreen )
                activeScreen.FocusScreen(screen);
            else
                screen.Focus();
        }
        
        public void FocusScreen(UIScreen screen)
        {
            if (screen == this)
            {
                Focus();
                return;
            }
        
            screen.previousScreen = this;
            screen.Focus();
            
            if (!screen.isModal)
            {
                Defocus();
            }
            else
            {
                _group.interactable = false;
            }
        }
        
        public void Defocus()
        {
            Hide();
            
            if (!isModal && previousScreen)
            {
                previousScreen.Focus();
            }
        }

        public void Hide()
        {
            Group.interactable = false;
            gameObject.SetActive(false);
        }
    
        public void Focus()
        {
            if (activeScreen == this && activeScreen.gameObject.activeInHierarchy)
                return;

            previousScreen = activeScreen;
            Group.interactable = true;
            gameObject.SetActive(true);
            activeScreen = this;
            
            if (!isModal)
                previousScreen.Hide();
        }
    }
}