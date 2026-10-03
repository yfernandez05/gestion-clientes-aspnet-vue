import Swal from 'sweetalert2';

const optionsAlert = {
  title: 'Sistema',
  html: 'Información para el usuario.',
  customClass: {
    confirmButton: 'btn btn-info mx-1',
    cancelButton: 'btn btn-danger mx-1'
  },
  buttonsStyling: false
};

window.swalAlertConfirm = function (message, title) {
  const selectOptions = {
    title: title,
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Confirmar',
    cancelButtonText: 'Cancelar',
    html: message,
  };

  const currentOptions = { ...optionsAlert, ...selectOptions };

  return Swal.fire(currentOptions);
};

window.swalAlertInfo = function (message, title) {
  const selectOptions = {
    title: title,
    icon: 'info',
    showCancelButton: false,
    confirmButtonText: 'Ok',
    html: message,
  };

  const currentOptions = { ...optionsAlert, ...selectOptions };

  return Swal.fire(currentOptions);
};

/* alert */

const toastOptions = {
  toast: true,
  position: 'top-end',
  showConfirmButton: false,
  timer: 3000,
  timerProgressBar: true,
  onOpen: (toast) => {
    toast.addEventListener('mouseenter', Swal.stopTimer);
    toast.addEventListener('mouseleave', Swal.resumeTimer);
  }
};

window.successMessage = function (message, title) {
  Swal.fire({
    ...toastOptions,
    icon: 'success',
    title: title || 'Éxito',
    text: message
  });
};

window.errorMessage = function (message, title) {
  Swal.fire({
    ...toastOptions,
    icon: 'error',
    title: title || 'Error',
    text: message
  });
};

window.warningMessage = function (message, title) {
  Swal.fire({
    ...toastOptions,
    icon: 'warning',
    title: title || 'Advertencia',
    text: message
  });
};

window.infoMessage = function (message, title) {
  Swal.fire({
    ...toastOptions,
    icon: 'info',
    title: title || 'Información',
    text: message
  });
};


