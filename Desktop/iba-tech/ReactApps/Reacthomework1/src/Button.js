import React from "react";
import PropTypes from "prop-types"

export const Button = ({ text, backgroundColor, onClick }) => {
    Button.propTypes = {
        text: PropTypes.string,
        backgroundColor: PropTypes.string,
        onClick: PropTypes.func
    }
    return (
        <button className="btn" style={{
            backgroundColor
        }} onClick={onClick}>
            {text}
        </button>
        
    )
}

export default Button;