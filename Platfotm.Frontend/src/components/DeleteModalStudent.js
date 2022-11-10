import { Button, Modal } from "react-bootstrap";

function DeleteModalStudent(props) {
  return (
    <Modal
      {...props}
      size="md"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton></Modal.Header>
      <Modal.Body>
        <h4>Are you sure you want to delete this student?</h4>
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={props.onHide} variant="primary">
          Go back
        </Button>
        <Button onClick={props.onHide} variant="danger">
          Delete
        </Button>
      </Modal.Footer>
    </Modal>
  );
}

export default DeleteModalStudent;
